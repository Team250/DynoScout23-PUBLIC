using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace FalconScout_v2017
{
    public partial class TimerForm : Form
    {
        
        public Stopwatch stopwatch = new Stopwatch();

        public TimerForm()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = Convert.ToString(stopwatch.Elapsed.Minutes) + ":" +
                Convert.ToString(stopwatch.Elapsed.Seconds) + ":" +
                Convert.ToString(stopwatch.Elapsed.Milliseconds);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stopwatch.Start();
            timer1.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Stop(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            stopwatch.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            
        }
        
    }
    
}
