using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yazılım_yapımı
{
   public class Ayarlar
    {
        Random rnd { get; set; }

        public int IkiBasamakli { get; set; }

        public List<int> TekBasamakli { get; private set; }

        public int HedefSayi { get; set; }

        IslemCozumu IslemCozumu { get; set; }


        
        public Ayarlar()
        {
            
            rnd = new Random();
            if (TekBasamakli != null) TekBasamakli.Clear();
            IkiBasamakli = IkiBasamakliOlustur();
            TekBasamakli = TekBasamakliOlustur();
            HedefSayi = HedefSayiOlustur();
        }

            
      
        public IslemCozumu Basla()
        {
           
            this.IslemCozumu = new IslemCozumu(HedefSayi, TekBasamakli, IkiBasamakli);
            return IslemCozumu;
        }
      
        private int IkiBasamakliOlustur()
        {
            List<int> sayilar = new List<int>() { 10, 20, 30, 40, 50, 60, 70, 80, 90 };
            return sayilar[rnd.Next(0, sayilar.Count)];
        }

        private List<int> TekBasamakliOlustur()
        {
            List<int> sayilar = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                sayilar.Add(rnd.Next(1, 9));
            }
            return sayilar;
        }

        private int HedefSayiOlustur()
        {
            return rnd.Next(100, 1000);
        }

        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(IslemCozumu);
            return sb.ToString();
        }
        
    }
}


