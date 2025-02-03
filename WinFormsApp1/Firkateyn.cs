using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Firkateyn : Deniz
    {
        public Firkateyn(int seviyePuani = 0) : base(seviyePuani)
        {
        }

        public Firkateyn(string altSinif, int havaVurusAvantaji, int dayaniklilik, string sinif, int vurus)
        {
            AltSinif = altSinif;
            HavaVurusAvantaji = havaVurusAvantaji;
            Dayaniklilik = dayaniklilik;
            Sinif = sinif;
            Vurus = vurus;
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
            Console.WriteLine($"Dayanıklılık: {Dayaniklilik}, Seviye Puanı: {SeviyePuani}");

        }
    }
}
