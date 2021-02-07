using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static yazılım_yapımı.Islem.Enums.Enum;

namespace yazılım_yapımı
{
    public class IslemHesap : Ayarlar
    {
        #region Properties
        private List<int> SiradakiSayi { get; set; }

        private List<IslemIsaretleri> Operatorler { get; set; }

        public int DegerHesapla
        {
           
            get
            {
                int deger = SiradakiSayi[0];
                for (int i = 1; i < SiradakiSayi.Count; i++)
                {
                    switch (Operatorler[i - 1])
                    {
                        case IslemIsaretleri.Ekle:
                            deger += SiradakiSayi[i];
                            break;
                        case IslemIsaretleri.Cikar:
                            deger -= SiradakiSayi[i];
                            break;
                        case IslemIsaretleri.Carp:
                            deger *= SiradakiSayi[i];
                            break;
                        case IslemIsaretleri.Bol:
                            deger /= SiradakiSayi[i];
                            break;
                    }
                }
                return deger;
            }
        }
       
        public IslemHesap(int _siradaki_sayi)
        {
            
            this.SiradakiSayi = new List<int>() { _siradaki_sayi };
            this.Operatorler = new List<IslemIsaretleri>();
        }

        public IslemHesap(IslemHesap _denklembaslangici, IslemIsaretleri _islem, int _siradakisayi)
        {
            
            this.SiradakiSayi = new List<int>((int[])_denklembaslangici.SiradakiSayi.ToArray().Clone());
            this.SiradakiSayi.Add(_siradakisayi);
            this.Operatorler = new List<IslemIsaretleri>((IslemIsaretleri[])_denklembaslangici.Operatorler.ToArray().Clone());
            this.Operatorler.Add(_islem);
        }
        
        public override string ToString()
        {
           
            StringBuilder sb = new StringBuilder();
            int siradaki = SiradakiSayi[0];
            int _siradakideger = -1;
            for (int i = 1; i < SiradakiSayi.Count; i++)
            {
                string satir = YeniIslemSatiriOlustur(siradaki, i, ref _siradakideger);
                sb.Append(satir);
                sb.Append(Environment.NewLine);
                siradaki = _siradakideger;
            }
            return sb.ToString();
        }

        private string YeniIslemSatiriOlustur(int _simdikisayi, int _kartsirasi, ref int _siradakideger)
        {
            
            int siradaki_sayi = SiradakiSayi[_kartsirasi];
            IslemIsaretleri islem = (IslemIsaretleri)Operatorler[_kartsirasi - 1];
            string islemsembol = IslemSembolEkle(islem);
            _siradakideger = YeniDegerHesapla(_simdikisayi, siradaki_sayi, islem);
            return string.Format("{0} {1} {2} = {3}", _simdikisayi, islemsembol, siradaki_sayi, _siradakideger);
        }

        private string IslemSembolEkle(IslemIsaretleri Operator)
        {
           
            switch (Operator)
            {
                case IslemIsaretleri.Ekle:
                    return "+";
                case IslemIsaretleri.Cikar:
                    return "-";
                case IslemIsaretleri.Carp:
                    return "*";
                case IslemIsaretleri.Bol:
                    return "/";
                default:
                    return null;
            }
        }

        private int YeniDegerHesapla(int _sayi1, int _sayi2, IslemIsaretleri _islem)
        {
            switch (_islem)
            {
                case IslemIsaretleri.Ekle:
                    return _sayi1 + _sayi2;
                case IslemIsaretleri.Cikar:
                    return _sayi1 - _sayi2;
                case IslemIsaretleri.Carp:
                    return _sayi1 * _sayi2;
                case IslemIsaretleri.Bol:
                    return _sayi1 / _sayi2;
                default:
                    return -1;
            }
        }
        #endregion ToString
    }


}