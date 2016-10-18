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
    public partial class Reg_sponsor : Form
    {
        public Reg_sponsor()
        {
            InitializeComponent();
        }
        one_line_query a = new one_line_query();
        Point pt;
        bool move = false;
        public string info;

        public static DataTable show()
        {
            string Query = "SELECT * FROM marathonskills2016.registration";
            MySqlConnection MyConn = new MySqlConnection(one_line_query.Connection);
            MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = MyCommand;
            DataTable dTable = new DataTable();
            MyAdapter.Fill(dTable);
            return dTable;
        }

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
            label9.Text = textBox7.Text;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string[] a = comboBox1.Text.Split(' ');
            string query = "USE marathonskills2016;UPDATE marathonskills2016.registration SET registration.SponsorshipTarget=registration.SponsorshipTarget+" + textBox7.Text + " WHERE RunnerId='" + a[2] + "';INSERT INTO marathonskills2016.`sponsorship` (`SponsorName`,`RegistrationId`,`Amount`) VALUES ('" + textBox1.Text + "',(SELECT RegistrationId FROM registration WHERE RunnerId='" + a[2] + "')," + textBox7.Text + ");";
            MySqlConnection MyConn = new MySqlConnection(one_line_query.Connection);
            MySqlCommand MyCommand = new MySqlCommand(query, MyConn);
            MySqlDataReader MyReader;
            //INSERT INTO marathonskills2016.`sponsorship` (`SponsorName`,`RegistrationId`,`Amount`) VALUES ('" + textBox1.Text + "',(SELECT RegistrationId FROM registration WHERE RunnerId='" + a[2] + "')," + textBox7.Text + ");;
            MyConn.Open();
            MyReader = MyCommand.ExecuteReader();
            while(MyReader.Read())
            {
                try
                {

                }
                catch
                {

                }
            }
            MyConn.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Reg_sponsor.show();
        }

        private void Reg_sponsor_Load(object sender, EventArgs e)
        {
            textBox1.Text = one_line_query.information;
            textBox5.MaxLength = 2;
            string line = "";
            int i = 0;
            int linelenght = 0;
            string connection = "Database=marathonskills2016;Data Source=localhost;User id=root;Password=12345";
            string query = "USE marathonskills2016; SELECT u.FirstName, u.LastName, r.RunnerId, c.CountryName FROM user u INNER JOIN runner r ON u.Email=r.Email INNER JOIN country c ON r.CountryCode=c.CountryCode WHERE u.RoleId='R'";
            MySqlConnection MyConn = new MySqlConnection(connection);
            MySqlCommand MyCommand = new MySqlCommand(query, MyConn);
            MySqlDataReader MyReader;
            MyConn.Open();
            MyReader = MyCommand.ExecuteReader();
            while(MyReader.Read())
            {
                try
                {
                    while (i < (MyReader.FieldCount))
                    {
                        if (i == MyReader.FieldCount)
                        {
                            line += MyReader.GetString(i);
                            linelenght++;
                            i++;
                        }
                        else
                        {
                            line += MyReader.GetString(i) + " ";
                            linelenght++;
                            i++;
                        }
                    }
                    comboBox1.Items.Add(line);
                    linelenght = 0;
                    line = "";
                    i = 0;
                }
                catch
                {
                }
            }
            MyConn.Close();
            pictureBox1.Image = Image.FromFile("C:/Users/Hastker/Desktop/cdCn-bnlHD8.jpg");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int a;
            if (textBox7.Text == "")
                a = 0;
            else 
                a = Convert.ToInt32(textBox7.Text);
            a += 10;
            textBox7.Text = Convert.ToString(a);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int a;
            if (textBox7.Text == "")
            {
                a = 0;
            }
            else if (Convert.ToInt32(textBox7.Text) < 10)
                a = 0;
            else
                a = Convert.ToInt32(textBox7.Text) - 10;
            textBox7.Text = Convert.ToString(a);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form fond = new Fond();
            fond.Show();
        }
    }
}
