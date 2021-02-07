using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yazılım_yapımı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Sidepanel.Height = button1.Height;
            Sidepanel.Top = button1.Top;
            kurallarUserControl1.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = button1.Height;
            Sidepanel.Top = button1.Top;
            kurallarUserControl1.BringToFront();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = button2.Height;
            Sidepanel.Top = button2.Top;
            ıslemUserControl1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Sidepanel.Height = button3.Height;
            Sidepanel.Top = button3.Top;
            kelimeUserControl2.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
