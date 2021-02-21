using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cps
{
    public partial class Form1 : Form
    {
        bool iff = true;
        class PerformanceTimer
        {
            [DllImport("Kernel32.dll")]
            private static extern bool QueryPerformanceCounter(
              out long lpPerformanceCount);

            [DllImport("Kernel32.dll")]
            private static extern bool QueryPerformanceFrequency(
              out long lpFrequency);

            private long startTime, stopTime;
            private long freq;

            public PerformanceTimer()
            {
                startTime = 0;
                stopTime = 0;

                if (QueryPerformanceFrequency(out freq) == false)
                {
                    throw new Exception("Timer not supported.");
                }
            }

            public void Start()
            {
                Thread.Sleep(0);
                QueryPerformanceCounter(out startTime);
            }

            public void Stop()
            {
                QueryPerformanceCounter(out stopTime);
            }

            public double Duration
            {
                get
                {
                    return (double)(stopTime - startTime) / (double)freq;
                }
            }

        }
        public void bc()
        {
            double ti = 0;
            while (true)
            {
                if(t-ti> 0.23 && t - ti < 0.232)
                {
                    button1.BackColor = Color.FromArgb(150, 80, 80);
                    ti = t;
                }
                else
                {
                    button1.BackColor = Color.FromArgb(233, 233, 233);
                }
            }
            
        }
        public Form1()
        {
            InitializeComponent();
        }
        PerformanceTimer timer = new PerformanceTimer();
        double t = 0;
        int cs = 1;
        double cps=0;


        private void button1_Click(object sender, EventArgs e)
        {
            //ThreadStart childref = new ThreadStart(bc);
            //Thread childThread = new Thread(childref);
            if (iff)
            {
                t = 0;
                iff =false;
                timer.Start();
                //ThreadStart childref = new ThreadStart(bc);
                //Thread childThread = new Thread(childref);
                //childThread.Start();
            }
            else
            {
                //childThread.Abort();
                timer.Stop();
                t = timer.Duration;
                textBox1.Text = t.ToString();
                textBox2.Text = (1 / t).ToString();
                textBox4.Text = Math.Round(1 / t, 3).ToString();
                if (cps < (1 / t))
                {
                    cps = 1 / t;
                }
                textBox3.Text = cps.ToString();
                if(Math.Round(1 / t, 3) - 4.317 < 0)
                {
                    textBox5.Text ="慢"+ (4.317-Math.Round(1 / t, 3)).ToString();
                }
                else
                {
                    textBox5.Text = "快" + (Math.Round(1 / t, 3) - 4.317).ToString();
                }
                
                timer.Start();
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            groupBox1.BackColor = Color.FromArgb(233, 88, 88);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            groupBox1.BackColor = Color.FromArgb(233, 233, 233);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            iff = true;
            cps = 0;
        }
    }
}
