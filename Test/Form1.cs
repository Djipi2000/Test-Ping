using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Test
{
    public partial class Form1 : Form
    {
        Ping ping_euw = new Ping();
        Series serie1 = new Series();
        long ping_every5;
        int compteur;
        
        public Form1()
        {
            InitializeComponent();
  //          Ping ping_euw = new Ping();  3
            chart1.Series.Add(serie1);
            compteur = 0;
            notifyIcon1.Text = "Lol Verificateur de Ping";
            notifyIcon1.Icon = new Icon("appicon.ico");
            notifyIcon1.Visible = true;
            notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
        }
        private void notifyIcon1_DoubleClick(object Sender, EventArgs e)
        {
            // Show the form when the user double clicks on the notify icon.

            // Set the WindowState to normal if the form is minimized.
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;

            // Activate the form.
            this.Activate();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            PingReply pingReply = ping_euw.Send("tavernaute.net");
            label1.Text = (pingReply.RoundtripTime.ToString() + "ms");
            ping_every5 = pingReply.RoundtripTime;

    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;
            timernotifyicon.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timernotifyicon.Enabled = false;
        }



        private void chart1_Click_1(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (compteur < 10)
            {
                serie1.Points.Add(ping_every5);
            }
            else
            {
                serie1.Points.Clear();
                serie1.Points.Add(ping_every5);
                compteur = 0;
            }
            compteur = compteur + 1;



        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            serie1.Points.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serie1.Points.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {
                
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timernotifyicon_Tick(object sender, EventArgs e)
        {
            if (ping_every5 >= 100)
            {
                notifyIcon1.Icon = SystemIcons.Exclamation;
                notifyIcon1.BalloonTipTitle = "Lol Ping";
                notifyIcon1.BalloonTipText = ("Votre ping est trop haut (" + ping_every5 + "ms)");
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning;
                notifyIcon1.ShowBalloonTip(60);
            }
        }
    }
}
