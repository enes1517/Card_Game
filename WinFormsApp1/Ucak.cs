using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Ucak : Hava
    {
       
            public Ucak(string altSinif, int karaVurusAvantaji, int dayaniklilik, string sinif, int vurus)
            {
                AltSinif = altSinif="Ucak";
                KaraVurusAvantaji = karaVurusAvantaji=10;
                Dayaniklilik = dayaniklilik=20;
                Sinif = sinif="Hava";
                Vurus = vurus;
            }
       

        public Ucak(int seviyePuani = 0) : base(seviyePuani)
        {
        }


        public override string AltSinif { get; set; }
            public override int KaraVurusAvantaji { get; set; }
            public override int Dayaniklilik { get; set; }
            public override string Sinif { get; set; }
            public override int Vurus { get; set; }

            public override void DurumGuncelle(int saldiriDegeri)
            {
            
            }

            public override void KartPuaniGoster()
            {
                Console.WriteLine($"Dayanıklılık: {Dayaniklilik}, Seviye Puanı: {SeviyePuani}");

            }
        




    }
}
