using AForge.Video.FFMPEG;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace screenSave
{
    class screenRecorder
    {

        Bitmap frame;
        Graphics graph;
        VideoFileWriter writer = new VideoFileWriter();
        static string saveFolder = "screenRecord";
        static int fps = 25;
        private int screenWidth = 0;
        private int screenHeight = 0;
        public bool applicationStatus = true;
        private Thread saver;

        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
        public screenRecorder()
        {
            checkSourceFiles();


            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();
            screenWidth = GetDeviceCaps(desktop, 118);//width
            screenHeight = GetDeviceCaps(desktop, 117);//height

        }
        private void checkSourceFiles()
        {
            if (!File.Exists("AForge.Video.DirectShow.dll"))
            {
                File.WriteAllBytes(@"AForge.Video.DirectShow.dll", Properties.Resources.AForge_Video_DirectShow);
            }

            if (!File.Exists("AForge.Video.dll"))
            {
                File.WriteAllBytes(@"AForge.Video.dll", Properties.Resources.AForge_Video);
            }

            if (!File.Exists("AForge.Video.FFMPEG.dll"))
            {
                File.WriteAllBytes(@"AForge.Video.FFMPEG.dll", Properties.Resources.AForge_Video_FFMPEG);
            }

            if (!File.Exists("avcodec-53.dll"))
            {
                File.WriteAllBytes(@"avcodec-53.dll", Properties.Resources.avcodec_53);
            }

            if (!File.Exists("avdevice-53.dll"))
            {
                File.WriteAllBytes(@"avdevice-53.dll", Properties.Resources.avdevice_53);
            }

            if (!File.Exists("avfilter-2.dll"))
            {
                File.WriteAllBytes(@"avfilter-2.dll", Properties.Resources.avfilter_2);
            }

            if (!File.Exists("avformat-53.dll"))
            {
                File.WriteAllBytes(@"avformat-53.dll", Properties.Resources.avformat_53);
            }

            if (!File.Exists("avutil-51.dll"))
            {
                File.WriteAllBytes(@"avutil-51.dll", Properties.Resources.avutil_51);
            }

            if (!File.Exists("swresample-0.dll"))
            {
                File.WriteAllBytes(@"swresample-0.dll", Properties.Resources.swresample_0);
            }

            if (!File.Exists("swscale-2.dll"))
            {
                File.WriteAllBytes(@"swscale-2.dll", Properties.Resources.swscale_2);
            }

            if (!File.Exists("tipskins.dll"))
            {
                File.WriteAllBytes(@"tipskins.dll", Properties.Resources.tipskins);
            }

            if (!File.Exists("zxing.dll"))
            {
                File.WriteAllBytes(@"zxing.dll", Properties.Resources.zxing);
            }



        }

        public void startRecord()
        {
            checkFolder();
            writer.Open(Application.StartupPath.ToString() + "/" + saveFolder + "/" + "record_" + DateTime.Now.ToString("dd_MM_yyyy___HH_mm_ss_ff").ToString() + ".asf", screenWidth, screenHeight, fps * 35 / 100, VideoCodec.MSMPEG4v3, 10000000);
            applicationStatus = true;
            try
            {
                saver.Abort();

            }
            catch
            {

            }
            saver = new Thread(new ThreadStart(saver_DoWork));
            saver.Start();
        }
        public void stopRecord()
        {
            if (writer.IsOpen)
            {
                writer.Close();
                applicationStatus = false;
            }
        }

        private void saver_DoWork()
        {
            do
            {
                try
                {
                    frame = new Bitmap(screenWidth, screenHeight);
                    graph = Graphics.FromImage(frame);
                    graph.CopyFromScreen(0, 0, 0, 0, new Size(frame.Width, frame.Height));
                    writer.WriteVideoFrame(frame);


                }
                catch
                {

                }
                Thread.Sleep(1000 / fps);
            } while (applicationStatus);
            if (writer.IsOpen)
            {
                writer.Close();
            }
        }
        private void checkFolder()
        {
            if (!Directory.Exists(Application.StartupPath.ToString() + "/" + saveFolder))
            {
                Directory.CreateDirectory(Application.StartupPath.ToString() + "/" + saveFolder);
            }
        }
    }
}
