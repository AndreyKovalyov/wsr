using MySql.Data.MySqlClient;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        one_line_query a = new one_line_query();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime current = DateTime.Now;
            DateTime finalday = new DateTime(2016, 10, 21, 0, 0, 0);
            TimeSpan raznica = finalday.Subtract(current);
            label5.Text = raznica.Days + " дней " + raznica.Hours + " часов " + raznica.Minutes + " минут до старта марафона!";
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string email = textBox1.Text;
                string pwd = textBox2.Text;
                string query = "USE marathonskills2016;SELECT * FROM user WHERE Email = '" + email + "' AND Password = '" + pwd + "';";
                string[] data = a.one_query(query);
                if(data[0] != null)
                {
                    this.Hide();
                    Form reg_sponsor = new Reg_sponsor();
                    reg_sponsor.Show();
                }
            }
            else
            {
                MessageBox.Show("Введите данные!");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f1 = new Form1();
            f1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = "a.adkin@dayrep.net";
            textBox2.Text = "jwZh2x@p";
        }
    }
}
