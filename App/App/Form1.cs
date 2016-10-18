using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Point pt;
        bool move = false;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            pt = new Point(e.X, e.Y);
            move = true;
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == true)
            {
                this.Location = new Point(this.Left + (e.X - pt.X), this.Top + (e.Y - pt.Y));
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime current = DateTime.Now;
            DateTime finalday = new DateTime(2016, 10, 21, 0, 0, 0);
            TimeSpan raznica = finalday.Subtract(current);
            label5.Text = raznica.Days + " дней " + raznica.Hours + " часов " + raznica.Minutes + " минут до старта марафона!";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f2 = new Form2();
            f2.Show();
        }
    }
}
