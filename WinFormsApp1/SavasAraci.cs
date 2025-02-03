using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.ComponentModel.Com2Interop;

namespace WinFormsApp1
{
    public abstract class SavasAraci
    {
        public abstract int Dayaniklilik { get; set; }
        public abstract string Sinif { get; set; }
        public abstract int Vurus { get; set; }

        // Seviye puanı özelliği
        public int SeviyePuani { get; set; }

        // Yapıcı metot
        public SavasAraci(int seviyePuani)
        {
            SeviyePuani = seviyePuani=0;
        }

        // Kart puanı gösterme metodu
        public virtual void KartPuaniGoster()
        {
            Console.WriteLine($"Dayanıklılık: {Dayaniklilik}, Seviye Puanı: {SeviyePuani}");

        }


        // Abstract metod: Durum Güncelle
        public abstract void DurumGuncelle(int saldiriDegeri);


    }
}
