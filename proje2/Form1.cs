using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Drawing;
using Label = System.Windows.Forms.Label;

namespace proje2_
{
    public partial class Form1 : Form
    {
        private List<Panel> secilenKartPanelleri = new List<Panel>();
        private List<SavasAraci> bilgisayarKartlari = new List<SavasAraci>();
        private List<SavasAraci> kullaniciKartlari = new List<SavasAraci>();
        private List<SavasAraci> temelKartlar = new List<SavasAraci>();
        private List<SavasAraci> gelistirilmisKartlar = new List<SavasAraci>();
        private HashSet<SavasAraci> kullanilmisKullaniciKartlari = new HashSet<SavasAraci>();
        private HashSet<SavasAraci> kullanilmisBilgisayarKartlari = new HashSet<SavasAraci>();
        private int maksimumHamleSayisi = 5;
        private int mevcutHamleSayisi = 0;
        List<string> elenenKullaniciKartlari = new List<string>();
        List<string> elenenBilgisayarKartlari = new List<string>();
        private Bilgisayar bilgisayar;
        private Kullanici kullanici;
        private bool oyunDevamEdiyor = false;

      

        Ucak Ucak = new Ucak
        {
            SeviyePuani = 0,
            Dayaniklilik = 20,
            Vurus = 10,
            Sinif = "Hava",
            AltSinif = "Ucak",
            KaraVurusAvantaji = 10
        };

        Siha siha = new Siha
        {
            SeviyePuani = 20,
            Dayaniklilik = 15,
            Vurus = 10,
            Sinif = "Hava",
            AltSinif = "Siha",
            DenizVurusAvantaji = 10,
        };

        Obus obus = new Obus
        {
            SeviyePuani = 0,
            Dayaniklilik = 20,
            Vurus = 10,
            Sinif = "Kara",
            AltSinif = "Obus",
            DenizVurusAvantaji = 5,



        };

        KFS kFS = new KFS
        {
            SeviyePuani = 20,
            Dayaniklilik = 10,
            Vurus = 10,
            Sinif = "Kara",
            AltSinif = "KFS",
            HavaVurusAvantaji = 20
        };

        Firkateyn firkateyn = new Firkateyn
        {
            SeviyePuani = 0,
            Dayaniklilik = 25,
            Vurus = 10,
            Sinif = "Deniz",
            AltSinif = "Firkateyn",
            HavaVurusAvantaji = 5
        };

        Sida sida = new Sida
        {
            SeviyePuani = 20,
            Dayaniklilik = 15,
            Vurus = 10,
            Sinif = "Deniz",
            AltSinif = "Sida",
            KaraVurusAvantaji = 10
        };


        private List<SavasAraci> KartListesi = new List<SavasAraci>();

        public Form1()
        {
            InitializeComponent();
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.AutoScroll = true;

            flowLayoutPanel2.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel2.AutoScroll = true;

            // Oyuncularý baþlat
            bilgisayar = new Bilgisayar(2, "Bilgisayar", 0);
            kullanici = new Kullanici(1, "Kullanýcý", 0);




            Panel myPanel = CreatePanelWithImage();
            // Paneli forma veya diðer kontrollere ekleyin
            this.Controls.Add(myPanel);











            // Temel kartlarý oluþtur
            temelKartlar.Add(new Ucak { SeviyePuani = 10, Dayaniklilik = 20, Vurus = 10, Sinif = "Hava", AltSinif = "Ucak", KaraVurusAvantaji = 10 });
            temelKartlar.Add(new Obus { SeviyePuani = 10, Dayaniklilik = 20, Vurus = 10, Sinif = "Kara", AltSinif = "Obus", DenizVurusAvantaji = 5 });
            temelKartlar.Add(new Firkateyn { SeviyePuani = 10, Dayaniklilik = 25, Vurus = 10, Sinif = "Deniz", AltSinif = "Firkateyn", HavaVurusAvantaji = 5 });
            temelKartlar.Add(new Obus { SeviyePuani = 10, Dayaniklilik = 20, Vurus = 10, Sinif = "Kara", AltSinif = "Obus", DenizVurusAvantaji = 5 });
            temelKartlar.Add(new Firkateyn { SeviyePuani = 10, Dayaniklilik = 25, Vurus = 10, Sinif = "Deniz", AltSinif = "Firkateyn", HavaVurusAvantaji = 5 });
            temelKartlar.Add(new Ucak { SeviyePuani = 10, Dayaniklilik = 20, Vurus = 10, Sinif = "Hava", AltSinif = "Ucak", KaraVurusAvantaji = 10 });
            temelKartlar.Add(new Ucak { SeviyePuani = 10, Dayaniklilik = 20, Vurus = 10, Sinif = "Hava", AltSinif = "Ucak", KaraVurusAvantaji = 10 });







            // Geliþtirilmiþ kartlarý oluþtur
            gelistirilmisKartlar.Add(new Siha { SeviyePuani = 20, Dayaniklilik = 15, Vurus = 10, Sinif = "Hava", AltSinif = "Siha", KaraVurusAvantaji = 10, DenizVurusAvantaji = 10 });
            gelistirilmisKartlar.Add(new KFS { SeviyePuani = 20, Dayaniklilik = 10, Vurus = 10, Sinif = "Kara", AltSinif = "KFS", DenizVurusAvantaji = 10, HavaVurusAvantaji = 20 });
            gelistirilmisKartlar.Add(new Sida { SeviyePuani = 20, Dayaniklilik = 15, Vurus = 10, Sinif = "Deniz", AltSinif = "Sida", HavaVurusAvantaji = 10, KaraVurusAvantaji = 10 });
        }

        private List<SavasAraci> RastgeleKartSec(int kartSayisi, bool bilgisayarIcin = false)
        {
            Random random = new Random();
            var uygunKartlar = new List<SavasAraci>();
            uygunKartlar.AddRange(temelKartlar);

            // Seviye 20 ve üzeri ise geliþmiþ kartlarý ekle
            if ((bilgisayarIcin && bilgisayar.skor >= 20) ||
                (!bilgisayarIcin && kullanici.skor >= 20))
            {
                uygunKartlar.AddRange(gelistirilmisKartlar);
            }

            // Kartlarý derin kopyala
            uygunKartlar = uygunKartlar.Select(k => k.Clone()).ToList();

            return uygunKartlar.OrderBy(x => random.Next()).Take(kartSayisi).ToList();
        }

        private void YeniOyunBaslat()
        {
            oyunDevamEdiyor = true;
            mevcutHamleSayisi = 0;
            kullaniciKartlari = RastgeleKartSec(6);
            bilgisayarKartlari = RastgeleKartSec(6, true);
            kullanilmisKullaniciKartlari.Clear();
            kullanilmisBilgisayarKartlari.Clear();
            secilenKartPanelleri.Clear();
            KartlariGoster();
        }

        private void KartlariGoster()
        {
            flowLayoutPanel1.BackgroundImage = Image.FromFile("C:\\Users\\HP\\Downloads\\Gemini_Generated_Image_kexvh8kexvh8kexv.jpg"); // Görsel dosya yolu
            flowLayoutPanel2.BackgroundImage = Image.FromFile("C:\\Users\\HP\\Downloads\\Gemini_Generated_Image_kexvh8kexvh8kexv.jpg"); // Görsel dosya yolu


            // Kullanýcý kartlarýný göster
            flowLayoutPanel1.Controls.Clear();
            foreach (var kart in kullaniciKartlari)
            {
                Panel kartPanel = KartPaneliOlustur(kart, false);
                kartPanel.BackgroundImage = Image.FromFile("C:\\Users\\HP\\Downloads\\d.png");

                flowLayoutPanel1.Controls.Add(kartPanel);
            }

            // Bilgisayar kartlarýný göster (kapalý olarak)
            flowLayoutPanel2.Controls.Clear();
            foreach (var kart in bilgisayarKartlari)
            {
                Panel kartPanel = KartPaneliOlustur(kart, true);
                kartPanel.BackgroundImage = Image.FromFile("C:\\Users\\HP\\Downloads\\Adsýz tasarým (2).png");
                flowLayoutPanel2.Controls.Add(kartPanel);
            }

            // Skor ve seviye bilgilerini güncelle
           
        }
        private Panel CreatePanelWithImage()
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackgroundImage = Image.FromFile("C:\\Users\\HP\\Downloads\\Gemini_Generated_Image_kexvh8kexvh8kexv.jpg"), // Görsel dosya yolu
                BackgroundImageLayout = ImageLayout.Stretch // Görsel boyuta sýðacak þekilde yayýlacak
            };

            return panel;
        }
        private Panel KartPaneliOlustur(SavasAraci kart, bool bilgisayarKarti)
        {
            Panel kartPanel = new Panel
            {
                Width = 150,
                Height = 200,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = bilgisayarKarti ? Color.White : Color.LightGray,

                Margin = new Padding(10),
                Tag = kart
               
            };
            Panel myPanel = CreatePanelWithImage();
            // Paneli forma veya diðer kontrollere ekleyin
            this.Controls.Add(myPanel);

            // Dayanýklýlýðý 0 veya daha düþük olan kartlar için týklama olayýný ekleme
            if (!bilgisayarKarti && kart.Dayaniklilik > 0)
            {
                kartPanel.Click += panel1_Click;
            }

            Label lblAd = new Label
            {
                Text = bilgisayarKarti ? "???" : kart.AltSinif,
                Font = new Font("Arial", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 30,
            };



            kartPanel.Controls.Add(lblAd);

            return kartPanel;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (!oyunDevamEdiyor) return;

            Panel kartPanel = (Panel)sender;
            SavasAraci secilenKart = (SavasAraci)kartPanel.Tag;

            // Elenmiþ kartý seçmeyi engelle
            if (secilenKart.Dayaniklilik <= 0)
            {
                MessageBox.Show("Bu kart elenmiþ durumda ve seçilemez!");
                return;
            }

            // Seviye kontrolü
            if (kullanici.skor < 20 && (secilenKart is Siha || secilenKart is Sida || secilenKart is KFS))
            {
                MessageBox.Show("Bu kartý seçmek için skorunuzun en az 20 olmasý gerekiyor!");
                return;
            }

            // Kart daha önce kullanýlmýþ mý kontrol et
            if (kullanilmisKullaniciKartlari.Contains(secilenKart))
            {
                // Tüm kartlar kullanýlmýþ mý kontrol et
                var kullanilabilirKartSayisi = kullaniciKartlari.Count(k => k.Dayaniklilik > 0);
                if (kullanilmisKullaniciKartlari.Count >= kullanilabilirKartSayisi)
                {
                    // Tüm kartlar kullanýlmýþsa, kullanýlmýþ kartlarý sýfýrla
                    kullanilmisKullaniciKartlari.Clear();
                }
                else
                {
                    MessageBox.Show("Bu kart zaten kullanýldý. Lütfen henüz kullanýlmamýþ bir kart seçin.");
                    return;
                }
            }

            if (secilenKartPanelleri.Contains(kartPanel))
            {
                secilenKartPanelleri.Remove(kartPanel);
                kartPanel.BackColor = Color.LightGray;
                kullanilmisKullaniciKartlari.Remove(secilenKart);
            }
            else
            {
                if (secilenKartPanelleri.Count >= 3)
                {
                    MessageBox.Show("En fazla 3 kart seçebilirsiniz.");
                    return;
                }

                secilenKartPanelleri.Add(kartPanel);
                kartPanel.BackColor = Color.LightBlue;
                kullanilmisKullaniciKartlari.Add(secilenKart);
            }
        }

        private void OyunuBitir()
        {
            oyunDevamEdiyor = false;

            int kullaniciToplamDayaniklilik = kullaniciKartlari
                .Where(k => k.Dayaniklilik > 0)
                .Sum(k => k.Dayaniklilik);

            int bilgisayarToplamDayaniklilik = bilgisayarKartlari
                .Where(k => k.Dayaniklilik > 0)
                .Sum(k => k.Dayaniklilik);

            string kazanan;
            if (kullanici.skor > bilgisayar.skor)
            {
                kazanan = "Kullanýcý";
            }
            else if (bilgisayar.skor > kullanici.skor)
            {
                kazanan = "Bilgisayar";
            }
            else // Skorlar eþit
            {
                if (kullaniciToplamDayaniklilik > bilgisayarToplamDayaniklilik)
                {
                    kazanan = "Kullanýcý";
                    int dayaniklilikFarki = kullaniciToplamDayaniklilik - bilgisayarToplamDayaniklilik;
                    kullanici.skor += dayaniklilikFarki;
                }
                else if (bilgisayarToplamDayaniklilik > kullaniciToplamDayaniklilik)
                {
                    kazanan = "Bilgisayar";
                    int dayaniklilikFarki = bilgisayarToplamDayaniklilik - kullaniciToplamDayaniklilik;
                    bilgisayar.skor += dayaniklilikFarki;
                }
                else
                {
                    kazanan = "Berabere";
                }
            }

            string sonucMesaji = $"Oyun bitti!\n\n" +
                                $"Kullanýcý Skor: {kullanici.skor}\n" +
                                $"Bilgisayar Skor: {bilgisayar.skor}\n" +
                                $"Sonuç: {kazanan}";
            if (kullanici.skor == bilgisayar.skor)
            {

                Console.WriteLine($"Bilgisayar Kalan Toplam Dayanýklýlýk: {bilgisayarToplamDayaniklilik}\n\n");
                Console.WriteLine($"Kullanýcý Kalan Toplam Dayanýklýlýk: {kullaniciToplamDayaniklilik}\n\n");
            }

            MessageBox.Show(sonucMesaji, "Oyun Sonu");
        }


        // Sýnýf seviyesinde tur sayýsýný takip etmek için deðiþken ekleyin
        private int turSayisi = 1;
        private void HamleyiTamamla()
        {
            if (secilenKartPanelleri.Count != 3)
            {
                MessageBox.Show("Lütfen 3 kart seçin.");
                return;
            }

            mevcutHamleSayisi++;

            // Bilgisayarýn kartlarýný seç
            Random random = new Random();
            var bilgisayarSecilenKartlar = bilgisayarKartlari
                .Where(k => k.Dayaniklilik > 0)
                .Where(k => !(bilgisayar.skor < 20 && (k is Siha || k is Sida || k is KFS)))
                .OrderBy(x => random.Next())
                .Take(3)
                .ToList();

            StringBuilder savasDetayi = new StringBuilder();
            StringBuilder SavasTxt = new StringBuilder();

            savasDetayi.AppendLine($"Tur {mevcutHamleSayisi}");

            SavasTxt.AppendLine($"===== TUR {mevcutHamleSayisi} DETAYLARI =====");
            SavasTxt.AppendLine($"Tur Baþlangýç Skorlarý - Bilgisayar: {bilgisayar.skor}, Kullanýcý: {kullanici.skor}\n");

            // Her tur için öldürülen kart sayýlarýný tutacak deðiþkenler
            int kullaniciOldurulenKartSayisi = 0;
            int bilgisayarOldurulenKartSayisi = 0;

            // Karþýlaþmalarý sýrayla gerçekleþtir
            for (int i = 0; i < 3; i++)
            {

                var kullaniciKart = (SavasAraci)secilenKartPanelleri[i].Tag;
                var bilgisayarKart = bilgisayarSecilenKartlar[i];

                var kullaniciKartOrijinalDayaniklilik = kullaniciKart.Dayaniklilik;
                var bilgisayarKartOrijinalDayaniklilik = bilgisayarKart.Dayaniklilik;

                // Her iki kartýn birbirine sýrayla saldýrýsý
                int kullaniciVurus = SaldiriHesapla(kullaniciKart, bilgisayarKart);
                bilgisayarKart.Dayaniklilik -= kullaniciVurus;

                int bilgisayarVurus = 0;
                if (bilgisayarKart.Dayaniklilik > 0)
                {
                    bilgisayarVurus = SaldiriHesapla(bilgisayarKart, kullaniciKart);
                    kullaniciKart.Dayaniklilik -= bilgisayarVurus;
                }


                SavasTxt.AppendLine($"\nKarþýlaþma {i + 1}:");
                SavasTxt.AppendLine($"Kullanýcý Kartý: {kullaniciKart.AltSinif}");
                SavasTxt.AppendLine($"- Orijinal Dayanýklýlýk: {kullaniciKartOrijinalDayaniklilik}");
                SavasTxt.AppendLine($"- Aldýðý Vuruþ: {bilgisayarVurus}");
                SavasTxt.AppendLine($"- Kalan Dayanýklýlýk: {kullaniciKart.Dayaniklilik}");
                SavasTxt.AppendLine($"- Seviye Puaný: {kullaniciKart.SeviyePuani}");

                SavasTxt.AppendLine($"Bilgisayar Kartý: {bilgisayarKart.AltSinif}");
                SavasTxt.AppendLine($"- Orijinal Dayanýklýlýk: {bilgisayarKartOrijinalDayaniklilik}");
                SavasTxt.AppendLine($"- Aldýðý Vuruþ: {kullaniciVurus}");
                SavasTxt.AppendLine($"- Kalan Dayanýklýlýk: {bilgisayarKart.Dayaniklilik}");
                SavasTxt.AppendLine($"- Seviye Puaný: {bilgisayarKart.SeviyePuani}");









                savasDetayi.AppendLine($"\nKarþýlaþma {i + 1}:");
                savasDetayi.AppendLine($"Kullanýcý Kartý: {kullaniciKart.AltSinif} (Orijinal Dayanýklýlýk: {kullaniciKartOrijinalDayaniklilik}, Vuruþ: {kullaniciVurus}, Kalan Dayanýklýlýk: {kullaniciKart.Dayaniklilik})");
                savasDetayi.AppendLine($"Bilgisayar Kartý: {bilgisayarKart.AltSinif} (Orijinal Dayanýklýlýk: {bilgisayarKartOrijinalDayaniklilik},Vuruþ:{bilgisayarVurus},Kalan Dayanýklýlýk:{bilgisayarKart.Dayaniklilik})");

                // Öldürülen kartlarý say ve seviye puanlarýný güncelle
                if (kullaniciKart.Dayaniklilik <= 0)
                {

                    elenenKullaniciKartlari.Add($"{kullaniciKart.AltSinif})");

                    bilgisayarOldurulenKartSayisi++;
                    // Elenen kartýn (kullanýcý kartý) seviye puanýna göre artýþ hesapla
                    int seviyeArtisi = Math.Max(10, kullaniciKart.SeviyePuani);
                    bilgisayarKart.SeviyePuani += seviyeArtisi;
                    bilgisayar.skor += seviyeArtisi; // Ayný miktarý skora da ekle
                    SavasTxt.AppendLine($"SONUÇ: Bilgisayar kartý kazandý! (+{seviyeArtisi} seviye puaný)");
                    savasDetayi.AppendLine($"Bilgisayar kartý kazandý! (+{seviyeArtisi} seviye puaný ve skor)");
                }
                if (bilgisayarKart.Dayaniklilik <= 0)
                {

                    elenenBilgisayarKartlari.Add($"{bilgisayarKart.AltSinif})");
                    kullaniciOldurulenKartSayisi++;
                    // Elenen kartýn (bilgisayar kartý) seviye puanýna göre artýþ hesapla
                    int seviyeArtisi = Math.Max(10, bilgisayarKart.SeviyePuani);
                    kullaniciKart.SeviyePuani += seviyeArtisi;
                    kullanici.skor += seviyeArtisi; // Ayný miktarý skora da ekle
                    SavasTxt.AppendLine($"SONUÇ: Kullanýcý kartý kazandý! (+{seviyeArtisi} seviye puaný)");
                    savasDetayi.AppendLine($"Kullanýcý kartý kazandý! (+{seviyeArtisi} seviye puaný ve skor)");
                }
            }



            SavasTxt.AppendLine($"\nTur Sonuç Özeti:");
            SavasTxt.AppendLine($"Kullanýcýnýn Öldürdüðü Kart Sayýsý: {bilgisayarOldurulenKartSayisi}");
            SavasTxt.AppendLine($"Bilgisayarýn Öldürdüðü Kart Sayýsý: {kullaniciOldurulenKartSayisi}");
            SavasTxt.AppendLine($"Tur Sonu Skorlarý - Bilgisayar: {bilgisayar.skor}, Kullanýcý: {kullanici.skor}");
            SavasTxt.AppendLine("=======================================\n");



            try
            {
                File.AppendAllText("savas.txt", SavasTxt.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dosyaya yazma hatasý: {ex.Message}");
            }







            savasDetayi.AppendLine("\n=== ELENEN KARTLAR ===");
            if (elenenKullaniciKartlari.Count > 0)
            {
                savasDetayi.AppendLine("\nKullanýcýnýn Elenen Kartlarý:");
                foreach (var kart in elenenKullaniciKartlari)
                {
                    savasDetayi.AppendLine($"- {kart}");
                }
            }
            if (elenenBilgisayarKartlari.Count > 0)
            {
                savasDetayi.AppendLine("\nBilgisayarýn Elenen Kartlarý:");
                foreach (var kart in elenenBilgisayarKartlari)
                {
                    savasDetayi.AppendLine($"- {kart}");
                }
            }

            // Toplam sonuçlarý göster
            if (kullaniciOldurulenKartSayisi > 0)
            {
                savasDetayi.AppendLine($"\nKullanýcý {kullaniciOldurulenKartSayisi} kart öldürdü!");
            }

            if (bilgisayarOldurulenKartSayisi > 0)
            {
                savasDetayi.AppendLine($"\nBilgisayar {bilgisayarOldurulenKartSayisi} kart öldürdü!");
            }

            if (kullaniciOldurulenKartSayisi == 0 && bilgisayarOldurulenKartSayisi == 0)
            {
                savasDetayi.AppendLine("\nTur berabere bitti!");
            }

            savasDetayi.AppendLine($"\nGüncel Skorlar - Bilgisayar: {bilgisayar.skor}, Kullanýcý: {kullanici.skor}");

            // Yeni kartlar ekle
            kullaniciKartlari.Add(RastgeleKartSec(1)[0]);
            bilgisayarKartlari.Add(RastgeleKartSec(1, true)[0]);

            if (kullaniciKartlari.Count == 1 || bilgisayarKartlari.Count == 1)
            {
                if (kullaniciKartlari.Count == 1)
                {
                    kullaniciKartlari.AddRange(RastgeleKartSec(2));
                }
                if (bilgisayarKartlari.Count == 1)
                {
                    bilgisayarKartlari.AddRange(RastgeleKartSec(2, true));
                }
                KartlariGoster();
                OyunuBitir();
                return;
            }

            if (mevcutHamleSayisi >= maksimumHamleSayisi)
            {
                KartlariYenile();
                secilenKartPanelleri.Clear();
                KartlariGoster();
                MessageBox.Show(savasDetayi.ToString(), "Savaþ Sonuçlarý");
                OyunuBitir();
                return;
            }

            turSayisi++;
            KartlariYenile();
            secilenKartPanelleri.Clear();
            KartlariGoster();

            MessageBox.Show(savasDetayi.ToString(), "Savaþ Sonuçlarý");
        }

        private int SaldiriHesapla(SavasAraci saldiran, SavasAraci hedef)
        {
            int toplamVurus = saldiran.Vurus;

            // Saldýran kartýn hedef kartýn sýnýfýna göre avantajýný kontrol et
            if (hedef.Sinif == "Kara" && saldiran.AltSinif == "Ucak")
            {
                toplamVurus += Ucak.KaraVurusAvantaji;
            }
            if (hedef.Sinif == "Kara" && saldiran.AltSinif == "Sida")
            {
                toplamVurus += sida.KaraVurusAvantaji;
            }
            else if (hedef.Sinif == "Hava" && saldiran.AltSinif == "KFS")
            {
                toplamVurus += kFS.HavaVurusAvantaji;
            }
            else if (hedef.Sinif == "Hava" && saldiran.AltSinif == "Firkateyn")
            {
                toplamVurus += firkateyn.HavaVurusAvantaji;
            }
            else if (hedef.Sinif == "Deniz" && saldiran.AltSinif == "Obus")
            {
                toplamVurus += obus.DenizVurusAvantaji;
            }
            else if (hedef.Sinif == "Deniz" && saldiran.AltSinif == "Siha")
            {
                toplamVurus += siha.DenizVurusAvantaji;
            }
            return toplamVurus;
        }

        private void KartlariYenile()
        {
            kullaniciKartlari = kullaniciKartlari.Where(k => k.Dayaniklilik > 0).ToList();
            bilgisayarKartlari = bilgisayarKartlari.Where(k => k.Dayaniklilik > 0).ToList();

            // Eðer kart sayýsý 1'e düþtüyse, 2 yeni kart ekle
            if (kullaniciKartlari.Count <= 1)
            {
                kullaniciKartlari.AddRange(RastgeleKartSec(2));
            }
            if (bilgisayarKartlari.Count <= 1)
            {
                bilgisayarKartlari.AddRange(RastgeleKartSec(2, true));
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            YeniOyunBaslat();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!oyunDevamEdiyor)
            {
                MessageBox.Show("Lütfen önce oyunu baþlatýn.");
                return;
            }
            HamleyiTamamla();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    // Savaþ aracý sýnýflarý



    public class Ucak : Hava
    {

        public Ucak(string altSinif, int karaVurusAvantaji, int dayaniklilik, string sinif, int vurus)
        {
            AltSinif = altSinif;
            KaraVurusAvantaji = karaVurusAvantaji;
            Dayaniklilik = dayaniklilik;
            Sinif = sinif;
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
        public override void DurumGuncelle(int saldiriDegeri, int avantaj)
        {
            Dayaniklilik -= saldiriDegeri;
            if (Dayaniklilik <= 0)
            {
                Dayaniklilik = 0;
            }
        }
        public override void KartPuaniGoster()
        {
            Console.WriteLine($"Altsinif:{AltSinif}  Seviye Puaný: {SeviyePuani} ");
        }
    }
}

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
    public override void DurumGuncelle(int saldiriDegeri, int avantaj)
    {
        Dayaniklilik -= saldiriDegeri;
        if (Dayaniklilik <= 0)
        {
            Dayaniklilik = 0;
        }
    }
    public override void KartPuaniGoster()
    {
        Console.WriteLine($"Altsinif:{AltSinif},Seviye Puaný: {SeviyePuani} ");
    }
}


public class Sida : Deniz
{
    public int KaraVurusAvantaji { get; set; }
    public override string AltSinif { get; set; }
    public override int HavaVurusAvantaji { get; set; }
    public override int Dayaniklilik { get; set; }
    public override string Sinif { get; set; }
    public override int Vurus { get; set; }
    public Sida(int seviyePuani = 0) : base(seviyePuani)
    {
    }
    public Sida(string altSinif, int havaVurusAvantaji, int dayaniklilik, string sinif, int vurus, int karaVurusAvantaji)
    {
        AltSinif = altSinif;
        HavaVurusAvantaji = havaVurusAvantaji;
        Dayaniklilik = dayaniklilik;
        Sinif = sinif;
        Vurus = vurus;
        KaraVurusAvantaji = karaVurusAvantaji;
    }

    public override void DurumGuncelle(int saldiriDegeri, int avantaj)
    {
        Dayaniklilik -= saldiriDegeri;
        if (Dayaniklilik <= 0)
        {
            Dayaniklilik = 0;
        }
    }
    public override void KartPuaniGoster()
    {
        Console.WriteLine($"Altsinif:{AltSinif},  Seviye Puaný: {SeviyePuani} ");
    }
}


public abstract class SavasAraci
{
    public abstract int Dayaniklilik { get; set; }
    public abstract string AltSinif { get; set; }
    public abstract string Sinif { get; set; }
    public abstract int Vurus { get; set; }
    // Seviye puaný özelliði
    public int SeviyePuani { get; set; }
    // Yapýcý metot
    public SavasAraci(int seviyePuani)
    {
        SeviyePuani = seviyePuani = 0;
    }
    // Kart puaný gösterme metodu
    public virtual void KartPuaniGoster()
    {
        Console.WriteLine($"Dayanýklýlýk: {Dayaniklilik}, Seviye Puaný: {SeviyePuani}");
    }
    // Abstract metod: Durum Güncelle
    public abstract void DurumGuncelle(int saldiriDegeri, int avantaj);
    public SavasAraci Clone()
    {
        return (SavasAraci)this.MemberwiseClone();
    }
}


public class Oyuncu
{
    // Sýnýf özellikleri
    public int oyuncuID { get; set; }
    public string oyuncuAdi { get; set; }
    public int skor { get; set; }
    public List<SavasAraci> kartListesi { get; set; } // Kartlar string olarak tutuluyor

    // Parametresiz yapýcý (default constructor)


    // Parametreli yapýcý
    public Oyuncu(int oyuncuID, string oyuncuAdi, int skor)
    {
        this.oyuncuID = oyuncuID;
        this.oyuncuAdi = oyuncuAdi;
        this.skor = skor;
        kartListesi = new List<SavasAraci>();

    }


    // Skor gösterme fonksiyonu
    public void SkorGoster()
    {
        Console.WriteLine(skor);
    }

    // Kart seçme fonksiyonu (bilgisayar ve kullanýcý için ayrý iþleyecek)

}

public class Bilgisayar : Oyuncu
{
    public Random random = new Random();

    public Bilgisayar(int oyuncuID, string oyuncuAdi, int skor) : base(oyuncuID, oyuncuAdi, skor)
    {
        this.oyuncuID = oyuncuID;
        this.oyuncuAdi = oyuncuAdi;
        this.skor = skor;
    }




}

public class Kullanici : Oyuncu
{
    public Kullanici(int oyuncuID, string oyuncuAdi, int skor) : base(oyuncuID, oyuncuAdi, skor)
    {
        this.oyuncuID = oyuncuID;
        this.oyuncuAdi = oyuncuAdi;
        this.skor = skor;
    }



}


public class Obus : Kara
{
    public Obus(int seviyePuani = 0) : base(seviyePuani)
    {
    }
    public Obus(string altSinif, int denizVurusAvantaji, int dayaniklilik, string sinif, int vurus)
    {
        AltSinif = altSinif;
        DenizVurusAvantaji = denizVurusAvantaji;
        Dayaniklilik = dayaniklilik;
        Sinif = sinif;
        Vurus = vurus;
    }
    public override string AltSinif { get; set; }
    public override int DenizVurusAvantaji { get; set; }
    public override int Dayaniklilik { get; set; }
    public override string Sinif { get; set; }
    public override int Vurus { get; set; }
    public override void DurumGuncelle(int saldiriDegeri, int avantaj)
    {
        Dayaniklilik -= saldiriDegeri;
        if (Dayaniklilik <= 0)
        {
            Dayaniklilik = 0;
        }
    }
    public override void KartPuaniGoster()
    {
        Console.WriteLine($"Altsinif:{AltSinif}, Seviye Puaný: {SeviyePuani} ");
    }
}



public class KFS : Kara
{
    public int HavaVurusAvantaji { get; set; }
    public KFS(int seviyePuani = 0) : base(seviyePuani)
    {
    }
    public KFS(string altSinif, int denizVurusAvantaji, int dayaniklilik, string sinif, int vurus, int havaVurusAvantaji)
    {
        AltSinif = altSinif;
        DenizVurusAvantaji = denizVurusAvantaji;
        Dayaniklilik = dayaniklilik;
        Sinif = sinif;
        Vurus = vurus;
        HavaVurusAvantaji = havaVurusAvantaji;
    }
    public override string AltSinif { get; set; }
    public override int DenizVurusAvantaji { get; set; }
    public override int Dayaniklilik { get; set; }
    public override string Sinif { get; set; }
    public override int Vurus { get; set; }
    public override void DurumGuncelle(int saldiriDegeri, int avantaj)
    {
        Dayaniklilik -= saldiriDegeri;
        if (Dayaniklilik <= 0)
        {
            Dayaniklilik = 0;
        }
    }
    public override void KartPuaniGoster()
    {
        Console.WriteLine($"Altsinif:{AltSinif}, Seviye Puaný: {SeviyePuani} ");
    }
}



public abstract class Kara : SavasAraci
{
    public abstract int DenizVurusAvantaji { get; set; }

    protected Kara(int seviyePuani = 0) : base(seviyePuani)
    {
    }
    public override void KartPuaniGoster()
    {
        Console.WriteLine($"Dayanýklýlýk: {Dayaniklilik}, Seviye Puaný: {SeviyePuani}");
    }
    public override void DurumGuncelle(int saldiriDegeri, int avantaj)
    {
        Dayaniklilik -= saldiriDegeri;
        if (Dayaniklilik <= 0)
        {
            Dayaniklilik = 0;
        }
    }
}



public abstract class Hava : SavasAraci
{
    public abstract int KaraVurusAvantaji { get; set; }

    // Yapýcý metot, üst sýnýfýn yapýcýsýna seviye puaný gönderir
    public Hava(int seviyePuani = 0) : base(seviyePuani)
    {
    }
    // Kart puaný gösterme metodunu gerekirse özelleþtirebiliriz
    public override void KartPuaniGoster()
    {
        Console.WriteLine($"Dayanýklýlýk: {Dayaniklilik}, Seviye Puaný: {SeviyePuani}");
    }
    // Durum güncelleme metodunu gerekirse özelleþtirebiliriz
    public override void DurumGuncelle(int saldiriDegeri, int avantaj)
    {
        Dayaniklilik -= saldiriDegeri; // Saldýrý deðeri kadar dayanýklýlýk azaltýlýr
        if (Dayaniklilik < 0) Dayaniklilik = 0; // Dayanýklýlýk sýfýrýn altýna düþmemeli
        SeviyePuani += 10; // Örnek olarak, her saldýrýdan sonra 10 puan eklenebilir
    }
}



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
    public override void DurumGuncelle(int saldiriDegeri, int avantaj)
    {
        Dayaniklilik -= saldiriDegeri;
        if (Dayaniklilik <= 0)
        {
            Dayaniklilik = 0;
        }
    }
    public override void KartPuaniGoster()
    {
        Console.WriteLine($"Altsinif:{AltSinif}, Seviye Puaný: {SeviyePuani} ");
    }
}

public abstract class Deniz : SavasAraci
{
    public abstract int HavaVurusAvantaji { get; set; }

    protected Deniz(int seviyePuani = 0) : base(seviyePuani)
    {
    }

    public override void KartPuaniGoster()
    {
        Console.WriteLine($"Dayanýklýlýk: {Dayaniklilik}, Seviye Puaný: {SeviyePuani}");
    }
    public override void DurumGuncelle(int saldiriDegeri, int avantaj)
    {
        Dayaniklilik -= saldiriDegeri;
        if (Dayaniklilik <= 0)
        {
            Dayaniklilik = 0;
        }
    }
}






