using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public abstract class Hava : SavasAraci
    {
        public abstract string AltSinif { get; set; }
        public abstract int KaraVurusAvantaji { get; set; }

        // Yapıcı metot, üst sınıfın yapıcısına seviye puanı gönderir
        public Hava(int seviyePuani=0) : base(seviyePuani)
        {
        }

        // Kart puanı gösterme metodunu gerekirse özelleştirebiliriz
        public override void KartPuaniGoster()
        {
            Console.WriteLine($"Dayanıklılık: {Dayaniklilik}, Seviye Puanı: {SeviyePuani}");
        }

        // Durum güncelleme metodunu gerekirse özelleştirebiliriz
        public override void DurumGuncelle(int saldiriDegeri)
        {
            Dayaniklilik -= saldiriDegeri; // Saldırı değeri kadar dayanıklılık azaltılır
            if (Dayaniklilik < 0) Dayaniklilik = 0; // Dayanıklılık sıfırın altına düşmemeli
            SeviyePuani += 10; // Örnek olarak, her saldırıdan sonra 10 puan eklenebilir
        }

    }
}
