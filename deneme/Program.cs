using WinFormsApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using deneme;
using System.Net.Http.Headers;
namespace WinFormsApp1
{
    

    public class Program
    {

        static void Main(string[] args)
        {
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
                SeviyePuani = 0,
                Dayaniklilik = 15,
                Vurus = 10,
                Sinif = "Hava",
                AltSinif = "Siha",
                KaraVurusAvantaji = 10,
                DenizVurusAvantaji=10,
            };

            Obus obus=new Obus
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
                SeviyePuani = 0,
                Dayaniklilik = 10,
                Vurus = 10,
                Sinif = "Kara",
                AltSinif = "KFS",
                DenizVurusAvantaji = 10,
                HavaVurusAvantaji=20
            };

            Firkateyn firkateyn = new Firkateyn
            {
                SeviyePuani = 0,
                Dayaniklilik = 25,
                Vurus = 10,
                Sinif = "Deniz",
                AltSinif = "Firkateyn",
                HavaVurusAvantaji=5
            };

            Sida sida = new Sida
            {
                SeviyePuani = 0,
                Dayaniklilik = 15,
                Vurus = 10,
                Sinif = "Deniz",
                AltSinif = "Sida",
                HavaVurusAvantaji = 10,
                KaraVurusAvantaji=10
            };




        }
       
    }

}
