using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyRTSGame
{
    public partial class Form1 : Form
    {
        Map m = new Map();
        RangerUnit ru = new RangerUnit();
        MeleeUnit mu = new MeleeUnit();

        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblMap_Click(object sender, EventArgs e)
        {
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblTime.Text = "0";
            m.loadMap();
            lblMap.Text = "";
            lblMap.Text = m.drawMap();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        int count = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = count + "";
            count++;
            lblMap.Text = "";
            //lblMap.Text = ru.moveTowards();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
