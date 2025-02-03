using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public abstract class Deniz : SavasAraci
    {
        public abstract string AltSinif { get; set; }
        public abstract int HavaVurusAvantaji { get; set; }

        protected Deniz(int seviyePuani=0) : base(seviyePuani)
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
