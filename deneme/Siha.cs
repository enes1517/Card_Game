using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1;

namespace deneme
{
    public class Siha : Hava
    {

       public int DenizVurusAvantaji { get; set; }

        public Siha(int seviyePuani = 0) : base(seviyePuani)
        {
        }

        public Siha(string altSinif, int karaVurusAvantaji, int dayaniklilik, string sinif, int vurus, int denizVurusAvantaji)
        {
            AltSinif = altSinif;
            KaraVurusAvantaji = karaVurusAvantaji;
            Dayaniklilik = dayaniklilik;
            Sinif = sinif;
            Vurus = vurus;
            DenizVurusAvantaji = denizVurusAvantaji;    
        }

        public override string AltSinif { get; set; }
        public override int KaraVurusAvantaji { get; set; }
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
