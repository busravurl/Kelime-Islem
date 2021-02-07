using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static yazılım_yapımı.Islem.Enums.Enum;

namespace yazılım_yapımı
{
    public class IslemCozumu
    {
        #region Properties
        public List<int> TumSayilar { get; private set; }

        public int Hedef2 { get; private set; }

        private IslemHesap IslemHesap { get; set; }

        private int enYakin = int.MaxValue;

        public int puan;

        

        
        public IslemCozumu(int _hedef, List<int> _tekbasamakli, int _ikibasamakli)
        {
            TumSayilar = new List<int>();

            this.Hedef2 = _hedef;
            this.TumSayilar.Add(_ikibasamakli);
            this.TumSayilar.AddRange(_tekbasamakli);
            Coz();
        }
      

      
        public void Coz()
        {
            for (int i = 0; i < TumSayilar.Count; i++)
            {
                IslemHesap _denklem = new IslemHesap(TumSayilar[i]);
                List<int> arttikliste = KisaListeOlustur(TumSayilar, i);
                if (CozumAra(_denklem, arttikliste))
                    break;
            }
        }

        private List<int> KisaListeOlustur(List<int> _eskiliste, int _sirano)
        {
            List<int> yeniliste = new List<int>();
            for (int i = 0; i < _eskiliste.Count; i++)
                if (i != _sirano)
                    yeniliste.Add(_eskiliste[i]);
            return yeniliste;
        }

        private bool CozumAra(IslemHesap _denklembaslangici, List<int> _artikliste)
        {
            for (int i = 0; i < _artikliste.Count; i++)
            {
                foreach (IslemIsaretleri islem in IslemIsaretleri.GetValues(typeof(IslemIsaretleri)))
                {
                    List<int> yeniartikliste = KisaListeOlustur(_artikliste, i);
                    int siradakisayi = _artikliste[i];
                    if (CozumeKartiEkle(siradakisayi, islem, _denklembaslangici, yeniartikliste))
                        return true;
                }
            }
            return false;
        }

        private bool CozumeKartiEkle(int _siradakisayi, IslemIsaretleri _islem, IslemHesap _denklembaslangici, List<int> _artikliste)
        {
            IslemHesap denklem = new IslemHesap(_denklembaslangici, _islem, _siradakisayi);

            if (Math.Abs(Hedef2 - denklem.DegerHesapla) <= enYakin)
            {
                enYakin = Math.Abs(Hedef2 - denklem.DegerHesapla);
                this.IslemHesap = denklem;
                if (denklem.DegerHesapla == Hedef2 )
                   
                   return true;
                 
            }

            if (_artikliste.Count == 0)
            {
               
                return false;
            }

            return  CozumAra(denklem, _artikliste);
        }
        #endregion Solve

        #region ToString
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.IslemHesap.ToString());

            int fark = Math.Abs(this.IslemHesap.DegerHesapla - Hedef2);
            string ifade;
            switch (fark)
            {
                case 0:
                    puan = 10;
                    ifade = "\n  Puan: 10" + Environment.NewLine + "(Tam Sonuç)";
                    break;
                case 1:
                    puan = 9;
                    ifade = "\n  Puan: 9" + Environment.NewLine + "(Bir Yaklaşık Sonuç)";
                    break;
                case 2:
                    puan = 8;
                    ifade = "\n  Puan: 8" + Environment.NewLine + "(İki Yaklaşık Sonuç)";
                    break;
                case 3:
                    puan = 7;
                    ifade = "\n  Puan: 7" + Environment.NewLine + "(Üç Yaklaşık Sonuç)";
                    break;
                case 4:
                    puan = 6;
                    ifade = "\n  Puan: 6" + Environment.NewLine + "(Dört Yaklaşık Sonuç)";
                    break;
                case 5:
                    puan = 5;
                    ifade = "\n  Puan: 5" + Environment.NewLine + "(Beş Yaklaşık Sonuç)";
                    break;
                case 6:
                    puan = 4;
                    ifade = "\n  Puan: 4" + Environment.NewLine + "(Altı Yaklaşık Sonuç)";
                    break;
                case 7:
                    puan = 3;
                    ifade = "\n  Puan: 3" + Environment.NewLine + "(Yedi Yaklaşık Sonuç)";
                    break;
                case 8:
                    puan = 2;
                    ifade = "\n  Puan: 2" + Environment.NewLine + "(Sekiz Yaklaşık Sonuç)";
                    break;
                case 9:
                    puan = 1;
                    ifade = "\n  Puan: 1" + Environment.NewLine + "(Dokuz Yaklaşık Sonuç)";
                    break;
                default:
                    puan = 0;
                    ifade = "\n Puan Alamadınız!" + Environment.NewLine + "Çözüm Bulunamadı";
                    break;
            }
            sb.Append(Environment.NewLine + ifade);

            return sb.ToString();
        }
        #endregion ToString
    }
}
