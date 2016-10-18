using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace App
{
    class one_line_query
    {
        public static string Connection = "Database=marathonskills2016; Data Source=localhost;User id=root;Password=12345;";
        public static string information;

        public string[] one_query(string a)
        {
            string Query = a;
            int i = 0;
            MySqlConnection MyConn = new MySqlConnection(Connection);
            MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
            MySqlDataReader MyReader;
            MyConn.Open();
            MyReader = MyCommand.ExecuteReader();
            string[] info = new string[MyReader.FieldCount];
            while (MyReader.Read())
            {
                try
                {
                    while(i < MyReader.FieldCount)
                    {
                        info[i] = MyReader.GetString(i);
                        i++;
                    }
                    i = 0;
                    while (i < info.Length)
                    {
                        if (i == info.Length - 1)
                        {
                            information += info[i];
                        }
                        else
                        {
                            information += info[i] + "#";
                        }
                        i++;
                    }
                }
                catch
                {
                }
            }
            MyConn.Close();
            if (info[0] == null)
            {
                 MessageBox.Show("Введены неверные данные!");
            }
            return info;
        }
    }
}
