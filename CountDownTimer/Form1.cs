using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace CountDownTimer
{
    public partial class Form1 : Form
    {
        int seconds = 0;
        int mode = 0;
        bool timer_mode = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(timer_mode == true)
            {
                btnStart.Text = "Start";
                timer1.Stop();

                timer_mode = false;
            }else
            {
                if (seconds == 0)
                {
                    seconds = 4 * 60;
                    mode = 0;
                }

                playSound();
                displayTime();
                btnStart.Text = "Pause";
                timer_mode = true;

                timer1.Start();
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds--;
            displayTime();

            if(mode ==0 && seconds == 30) 
            {
                playSound();
            }else if (mode == 1 && seconds == 60)
            {
                playSound();
            }

            if(seconds < 0)
            {
                timer1.Stop();
            }
        }

        public void playSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\bell.wav");
            simpleSound.Play();
        }

        public void displayTime()
        {
            String time = "";
            int secs = seconds % 60;
            int mins = seconds / 60;

            if(mins < 10)
            {
                time += "0";
            }

            time += mins.ToString() + ":";

            if (secs < 10)
            {
                time += "0";
            }
            time += secs.ToString();

            lblTime.Text = time;
        }

        private void btnBell_Click(object sender, EventArgs e)
        {
            playSound();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mode = 0;
            seconds = 4 * 60;
            displayTime();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mode = 1;
            seconds = 5 * 60;
            displayTime();
        }

        private void btnPause_Click(object sender, EventArgs e)// actually reset
        {
            if(timer1.Enabled)
            {
                timer1.Stop();
            }

            seconds = 0;
            displayTime();

            btnStart.Text = "Start";
            timer_mode = false;
        }
    }
}
