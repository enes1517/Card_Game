using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1;

namespace deneme
{
    public class Oyuncu
    {
        // Sınıf özellikleri
        public int oyuncuID { get; set; }
        public string oyuncuAdi { get; set; }
        public int skor { get; set; }
        public List<SavasAraci> kartListesi { get; set; } // Kartlar string olarak tutuluyor

        // Parametresiz yapıcı (default constructor)
        public Oyuncu()
        {
            oyuncuID = 0;
            oyuncuAdi = "";
            skor = 0;
            kartListesi = new List<SavasAraci>();
        }

        // Parametreli yapıcı
        public Oyuncu(int oyuncuID, string oyuncuAdi, int skor)
        {
            this.oyuncuID = oyuncuID;
            this.oyuncuAdi = oyuncuAdi;
            this.skor = skor;
        }


        // Skor gösterme fonksiyonu
        public void SkorGoster()
        {
            Console.WriteLine($"{oyuncuAdi} skor: {skor}");
        }

        // Kart seçme fonksiyonu (bilgisayar ve kullanıcı için ayrı işleyecek)
        public virtual SavasAraci kartSec()
        {
            return null; // Ana sınıfta herhangi bir işlem yapılmıyor, alt sınıflarda özelleştirilecek
        }
    }

    public class Bilgisayar : Oyuncu
    {
        private Random random = new Random();

        public Bilgisayar(int oyuncuID) : base(oyuncuID, "Bilgisayar", 0) { }

        // Bilgisayarın rastgele kart seçmesi
        public override SavasAraci kartSec()
        {
            
            int index = random.Next(kartListesi.Count); // Rastgele bir indeks seç
            
            return kartListesi[index];
        }
    }

    public class Kullanici : Oyuncu
    {
        public Kullanici( int oyuncuID, string oyuncuAdi) : base(oyuncuID, oyuncuAdi, 0) { }

        // Kullanıcı kendi kartını seçiyor
        public override SavasAraci kartSec()
        {
            Console.WriteLine("Kartlarınız: ");
            for (int i = 0; i < kartListesi.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {kartListesi[i]}");
            }

            Console.Write("Bir kart seçin: ");

            int secim = Convert.ToInt32(Console.ReadLine()) - 1;
            
            return kartListesi[secim];


        }
    }






}

