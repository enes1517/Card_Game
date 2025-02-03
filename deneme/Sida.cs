using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1;

namespace deneme
{
    public class Sida : Deniz
    {
       public int KaraVurusAvantaji { get; set; }
        public Sida(int seviyePuani = 0) : base(seviyePuani)
        {
        }

        public Sida(string altSinif, int havaVurusAvantaji, int dayaniklilik, string sinif, int vurus,int karaVurusAvantaji)
        {
            AltSinif = altSinif;
            HavaVurusAvantaji = havaVurusAvantaji;
            Dayaniklilik = dayaniklilik;
            Sinif = sinif;
            Vurus = vurus;
            KaraVurusAvantaji=karaVurusAvantaji;
        }

        public override string AltSinif { get; set; }
        public override int HavaVurusAvantaji { get; set; }
        public override int Dayaniklilik { get; set; }
        public override string Sinif { get; set; }
        public override int Vurus { get; set; }

        public override void DurumGuncelle(int saldiriDegeri)
        {
            base.DurumGuncelle(saldiriDegeri);
        }

        public override void KartPuaniGoster()
        {
            base.KartPuaniGoster();
        }
    }
}
