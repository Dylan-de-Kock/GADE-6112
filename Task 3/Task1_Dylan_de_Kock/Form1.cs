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
            if (txtMap.Text.Equals(""))
            {
                txtMap.Text = m.generateMap();
            }
            else
            {

            }
            
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
            //if (count == 10)
            //{
            //    m.change();
            //    Timer.Stop();
            //}
            //lblResources.Text == "" + 
            

        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            Timer.Stop();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            m.save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m.loadMap();
            txtMap.Text = m.mapTick();
        }

        public void displaySuccess(string message)
        {
            MessageBox.Show(message, "Load Success", MessageBoxButtons.OK);
        }

        private void txtMap_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMap_Click(Object sender, EventArgs e)
        {
            
            int mouseX = MousePosition.X;
            int mouseY = MousePosition.Y;

            int formX = this.Location.X;
            int formY = this.Location.Y;

            int y = (mouseX - formX - 44) / 18;
            int x = (mouseY - formY - 74) / 17;

            txtDisplay.Text = "Form X = " + formX + Environment.NewLine + "Form Y = " + formY + Environment.NewLine;
            txtDisplay.Text = "Mouse X = " + mouseX + Environment.NewLine + "Mouse Y = " + mouseY + Environment.NewLine;
            txtDisplay.Text = "X = " + x + Environment.NewLine + "Y = " + y + Environment.NewLine;

            foreach (Unit u in m.Units)
            {
                if (u.x == x && u.y == y)
                {
                    if (u.x == x && u.y == y)
                    {
                        txtDisplay.Text += u.ToString();
                    }
                }
            }
        }

        private void txtDisplay_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
