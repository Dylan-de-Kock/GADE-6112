using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Task1_Dylan_de_Kock
{
    public partial class Form1 : Form
    {
        private Map m = new Map();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            m.resetMap();
            txtMap.Text = "";
            txtMap.Text = m.generateMap();
            var box = txtMap;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtMap.Text = m.generateMap();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("R u sur??", "Want to exit?", MessageBoxButtons.OKCancel);

            if (dr == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Timer.Start();
        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        int count = 1;
        private void Timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = count + "";
            count++;
            GameEngine ge = new GameEngine();
            ge.gameTick(m);
            //foreach (Unit u in m.Units)
            //{
            //    m.moveUnit(u);
            //}
            txtMap.Text = m.mapTick();

            //lblResources.Text == "" + 
            

        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            Timer.Stop();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
