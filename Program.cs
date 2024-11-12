using System.Diagnostics.Metrics;

namespace ButikSinemaUygulamasi_TP115
{
    internal class Program
    {
        static Sinema snm;
        static void Main(string[] args)
        {
            Uygulama();

            //snm.FilmAdi = "Avengers";     ----> Set etmek.
            //Console.WriteLine(snm.FilmAdi); ---> get --> okumak

            //Test();

            
        }

        static void Test()
        {
            while (true)
            {
                Console.WriteLine("Sayı Giriniz :");
                string giris = (Console.ReadLine());

                int sayi;

                bool sonuc = int.TryParse(giris, out sayi);

                if (sonuc == true)
                {
                    Console.WriteLine("Sayının 2 katı " + sayi * 2);
                }
                else
                {
                    Console.WriteLine("Hatalı giriş yapıldı");
                }

            }
        }

        //Şimdi Öyle bir metot yapın ki Bu metot Sayı girişinin doğru olup olmadığını kontrol eden
        //bir metot olsun.

        static int SayıAl(string mesaj)
        {
            int sayi;

            while (true)
            {
                Console.Write(mesaj);
                string giris = Console.ReadLine();

                if (int.TryParse(giris, out sayi))
                {
                    return sayi;
                }
                else
                {
                    Console.WriteLine("Hatalı Giriş Yapıldı");
                }
            }
        }



        static void Uygulama()
        {
            Kurulum();
            Console.WriteLine();
            Menu();

            while (true)
            {
                string giris = SecimAl();

                switch (giris)
                {
                    case "1":
                    case "S":
                        BiletSat();
                        break;
                    case "2":
                    case "R":
                        BiletIade();
                        break;
                    case "3":
                    case "D":
                        DurumBilgisi();
                        break;
                    case "4":
                    case "X":
                        Environment.Exit(0);
                        break;
                }
            }
        }

        static void Kurulum()
        {
            Console.WriteLine("-------Butik Sinema Salonu-------");
            Console.WriteLine();
            Console.Write("Film Adı : ");
            string film = Console.ReadLine();

            //Console.Write("Kapasite :");
            int kapasite = SayıAl("Kapasite :");

            //Console.WriteLine("Tam Bilet Fiyatı : ");
            int tam = SayıAl("Tam Bilet Fiyatı : ");

            //Console.Write("Yarım Bilet Fiyatı : ");
            int yarim = SayıAl("Yarım Bilet Fiyatı : ");

            snm = new Sinema(film, kapasite, tam, yarim);




        }

        static void Menu()
        {
            Console.WriteLine("1- Bilet Sat (S)");
            Console.WriteLine("2- Bilet İade (R) ");
            Console.WriteLine("3- Durum Bilgisi (D)");
            Console.WriteLine("4- Çıkış (X)");

        }

        static string SecimAl()
        {
            //kullanıcını yaptığı seçimleri almak için oluşturuduk.

            string karakterler = "1234SRDX";
            int sayac = 0;


            while (true)
            {
                sayac++;
                Console.WriteLine("Seçiminiz : ");
                string giris = Console.ReadLine();
                int index = karakterler.IndexOf(giris);

                Console.WriteLine();

                if (index >= 0)
                {
                    return giris;
                }

                else
                {
                    if (sayac == 10)
                    {
                        Console.WriteLine("Üzgünüm sizi anlamıyorum.Program Sonlandırılıyor.");
                        Environment.Exit(0);
                    }

                    Console.WriteLine("Hatalı işlem yapıldı");
                }
                Console.WriteLine();
            }
        }

        static void BiletSat()
        {
            Console.WriteLine("Bilet Sat");
            Console.WriteLine();

            //Console.Write();
            int tam = SayıAl("Tam Bilet Adeti : ");

            Console.Write("Yarım Bilet Adeti : ");
            //int yarim = int.Parse(Console.ReadLine());
            int yarim = SayıAl("Yarım Bilet Adeti : ");

            snm.BiletSatisi(tam, yarim);


        }

        static void BiletIade()
        {
            Console.WriteLine("Bilet İade");
            Console.WriteLine();

            Console.Write("Tam Bilet Adeti : ");
            int tam = int.Parse(Console.ReadLine());

            Console.Write("Yarım Bilet Adeti : ");
            int yarim = int.Parse(Console.ReadLine());

            snm.BiletIade(tam, yarim);
        }

        static void DurumBilgisi()
        {
            Console.WriteLine("Durum Bilgisi");
            Console.WriteLine("Film : " + snm.FilmAdi);
            Console.WriteLine("Kapasite :" + snm.Kapasite);
            Console.WriteLine("Tam Bilet Fiyatı :" + snm.TamBiletFiyati);
            Console.WriteLine("Yarım Bilet Fiyatı :" + snm.YarimBiletFiyati);
            Console.WriteLine("Toplam Tam Bilet Adeti :" + snm.ToplamTamBiletAdeti);
            Console.WriteLine("Toplam Yarım Bilet Adeti :" + snm.ToplamYarimBiletAdeti);
            //snm.CiroHesapla();
            Console.WriteLine("Ciro : " + snm.Ciro);
            Console.WriteLine("Boş Koltuk Adeti : " + snm.BosKoltukAdetiGetir());






        }


    }
}