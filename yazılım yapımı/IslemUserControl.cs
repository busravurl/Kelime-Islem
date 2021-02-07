using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using yazılım_yapımı;

namespace yazılım_yapımı
{
    public partial class IslemUserControl : UserControl
    {
        public IslemUserControl()
        {
            InitializeComponent();
        }
      
        Ayarlar oyunayarlari = new Ayarlar();

        private void button2_Click(object sender, EventArgs e)
        {


            try
            {

                oyunayarlari = new Ayarlar();

                lstIslemler.Items.Clear();

                textBox1.Text = oyunayarlari.TekBasamakli[0].ToString();
                textBox2.Text = oyunayarlari.TekBasamakli[1].ToString();
                textBox3.Text = oyunayarlari.TekBasamakli[2].ToString();
                textBox4.Text = oyunayarlari.TekBasamakli[3].ToString();
                textBox5.Text = oyunayarlari.TekBasamakli[4].ToString();
                textBox6.Text = oyunayarlari.IkiBasamakli.ToString();
                textBox7.Text = oyunayarlari.HedefSayi.ToString();
            }
            catch (Exception)
            {

                throw;
            }

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
           

            try
            {


               lstIslemler.Items.Clear();
             
                oyunayarlari.TekBasamakli[0] = Convert.ToInt32(textBox1.Text);
                oyunayarlari.TekBasamakli[1] = Convert.ToInt32(textBox2.Text);
                oyunayarlari.TekBasamakli[2] = Convert.ToInt32(textBox3.Text);
                oyunayarlari.TekBasamakli[3] = Convert.ToInt32(textBox4.Text);
                oyunayarlari.TekBasamakli[4] = Convert.ToInt32(textBox5.Text);
                oyunayarlari.IkiBasamakli = Convert.ToInt32(textBox6.Text);
                oyunayarlari.HedefSayi = Convert.ToInt32(textBox7.Text);

                var ifd = oyunayarlari.Basla();

                lstIslemler.Items.Add(ifd.ToString());
              

            }

            catch (Exception)
            {
                throw;
            }



        }

      
    }
}
