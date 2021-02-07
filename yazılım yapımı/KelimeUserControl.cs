using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yazılım_yapımı
{
    public partial class KelimeUserControl : UserControl
    {
        public static int puan = 0;
        public static Random rnd = new Random();
        public static string[] bulunanKelimeler = new string[200];
        public static int k = 0;
        public KelimeUserControl()
        {
            InitializeComponent();
        }

        public static void GetRandomString(TextBox txtbx)
        {
            string harfler = "abcçdefgğhıijklmnoöpqrsştuüvyz";
            int num = rnd.Next(0, harfler.Length - 1);
            txtbx.Text = harfler[num].ToString();
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            puan = 0;
            TextBox[] textboxlar =
                {textBox1,textBox2,textBox3,textBox4,textBox5,textBox6,textBox7,textBox8 ,textBox9};
            for (int i = 0; i < textboxlar.Length; i++)
            {
                GetRandomString(textboxlar[i]);
            }

            int num = rnd.Next(1, 9);
            GetRandomString(textboxlar[num]);
            textBox9.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kelimeler_lst.Items.Clear();

            String[] Input = {
                textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text,textBox5.Text,textBox6.Text,textBox7.Text,textBox8.Text ,textBox9.Text};
            string dosya_yolu = @"C:\Users\Büşra\Desktop\Dersler\Yazılım Yapımı\TDK_Sözlük_Kelime_Listesi.txt";
            string[] wordList = System.IO.File.ReadAllLines(dosya_yolu, Encoding.UTF8);

            HashSet<String> s_Words = new HashSet<String>(wordList);

            Dictionary<string, String[]> s_Dict = s_Words
                .Select(word => new
                {
                    Key = String.Concat(word.OrderBy(c => c)),
                    Value = word
                })
                .GroupBy(item => item.Key, item => item.Value)
                .ToDictionary(chunk => chunk.Key, chunk => chunk.ToArray());

            string source = String.Concat(Input.OrderBy(c => c));

            var result = Enumerable
                .Range(1, (1 << source.Length) - 1)
                .Select(index => string.Concat(source.Where((item, idx) => ((1 << idx) & index) != 0)))
                .SelectMany(key =>
                {
                    String[] words;
                    if (s_Dict.TryGetValue(key, out words))
                        return words;
                    else
                        return new String[0];
                })
                .Distinct()
                .OrderBy(word => word);
            foreach (string s in result)
            {
                switch (s.Length)
                {
                    case 3:
                        puan += 3;
                        break;
                    case 4:
                        puan += 4;
                        break;
                    case 5:
                        puan += 5;
                        break;
                    case 6:
                        puan += 7;
                        break;
                    case 7:
                        puan += 9;
                        break;
                    case 8:
                        puan += 11;
                        break;
                    case 9:
                        puan += 15;
                        break;
                    default:
                        break;
                }
                Kelimeler_lst.Items.Add(s);
            }

            puanlbl.Text = puan.ToString();

            if (Kelimeler_lst.Items.Count == 0)
                textBox9.Enabled = true;
        }

       
    }



}
   

