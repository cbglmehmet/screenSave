using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace screenSave
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        screenRecorder recorder = new screenRecorder();
        private void button1_Click(object sender, EventArgs e)
        {
            recorder.startRecord();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            recorder.stopRecord();
        }
    }
}
