using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1;

namespace deneme
{
    public class KFS : Kara
    {
       public int HavaVurusAvantaji { get; set; }
        public KFS(int seviyePuani = 0) : base(seviyePuani)
        {
        }

        public KFS(string altSinif, int denizVurusAvantaji, int dayaniklilik, string sinif, int vurus,int havaVurusAvantaji)
        {
            AltSinif = altSinif;
            DenizVurusAvantaji = denizVurusAvantaji;
            Dayaniklilik = dayaniklilik;
            Sinif = sinif;
            Vurus = vurus;
            HavaVurusAvantaji= havaVurusAvantaji;
        }

        public override string AltSinif { get; set; }
        public override int DenizVurusAvantaji { get; set; }
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
