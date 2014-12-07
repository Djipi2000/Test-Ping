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
        
        public Form1()
        {
            InitializeComponent();
  //          Ping ping_euw = new Ping();  3
            chart1.Series.Add(serie1);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PingReply pingReply = ping_euw.Send("google.fr");
            label1.Text = (pingReply.RoundtripTime.ToString() + "ms");
            ping_every5 = pingReply.RoundtripTime;

    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            serie1.Points.Add(ping_every5);

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            serie1.Points.Clear();
        }
    }
}
