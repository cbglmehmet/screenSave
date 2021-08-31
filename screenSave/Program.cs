using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace screenSave
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            checkSourceFiles();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void checkSourceFiles()
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
    }
}
