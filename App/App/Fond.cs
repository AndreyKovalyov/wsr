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
    public partial class Fond : Form
    {
        public Fond()
        {
            InitializeComponent();
        }

        Point pt;
        bool capture = false;

        private void Fond_Load(object sender, EventArgs e)
        {

        }

        private void Fond_MouseDown(object sender, MouseEventArgs e)
        {
            pt = new Point(e.X, e.Y);
            capture = true;
            
        }

        private void Fond_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void Fond_MouseUp(object sender, MouseEventArgs e)
        {
            capture = false;
        }

        private void Fond_MouseMove(object sender, MouseEventArgs e)
        {
            if (capture == true)
                this.Location = new Point(this.Left + (e.X - pt.X), this.Top + (e.Y - pt.Y));
        }

    }
}
