using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public abstract class Kara : SavasAraci
    {
        public abstract string AltSinif { get; set; }
        public abstract int DenizVurusAvantaji { get; set; }

       
        protected Kara(int seviyePuani=0) : base(seviyePuani)
        {
        }

        public override void KartPuaniGoster()
        {
            Console.WriteLine($"Dayanıklılık: {Dayaniklilik}, Seviye Puanı: {SeviyePuani}");

        }

        public override void DurumGuncelle(int saldiriDegeri)
        {

        }
    }
}
