using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_of_hotel
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 obj1 = new Form4();
            obj1.ShowDialog();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void managToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 obj1 = new Form5();
            obj1.ShowDialog();
        }

        private void manaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 obj1 = new Form6();
            obj1.ShowDialog();
        }

        private void manageEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 obj1 = new Form8();
            obj1.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(pictureBox1.Visible==true)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
            }
            else if(pictureBox2.Visible==true)
            {
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;
            }
            else if(pictureBox3.Visible==true)
            {
                pictureBox3.Visible = false;
                pictureBox4.Visible = true;
            }
            else if(pictureBox4.Visible==true)
            {
                pictureBox4.Visible = false;
                pictureBox5.Visible = true;
            }
            else if(pictureBox5.Visible==true)
            {
                pictureBox5.Visible = false;
                pictureBox6.Visible = true;
            }
            else if(pictureBox6.Visible==true)
            {
                pictureBox6.Visible = false;
                pictureBox7.Visible = true;
            }
            else
            {
                pictureBox7.Visible = false;
                pictureBox1.Visible = true;
            }
        }
           
        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
    }
}
