using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikSinemaUygulamasi_TP115
{
    internal class Sinema
    {
        public string FilmAdi { get; }
        public int Kapasite;
        public int TamBiletFiyati;
        public int YarimBiletFiyati;
        public int ToplamTamBiletAdeti;
        public int ToplamYarimBiletAdeti;
        public float Ciro
        {
            get
            {
                return this.TamBiletFiyati * this.ToplamTamBiletAdeti + this.YarimBiletFiyati * this.ToplamYarimBiletAdeti;
            }
            set 
            {
                //Cironun içerisinde 1000'den fazla değer olmasın.
                // Tek sayılar eklenmesin.
            }
        }

        public Sinema(string filmAdi, int kapasite, int tam, int yarim)
        {
            this.FilmAdi = filmAdi;
            this.Kapasite = kapasite;
            this.TamBiletFiyati = tam;
            this.YarimBiletFiyati = yarim;
        }

        public void BiletSatisi(int tamBiletAdeti, int yarimBiletAdeti)
        {
            if (tamBiletAdeti + yarimBiletAdeti <= BosKoltukAdetiGetir())
            {
                this.ToplamTamBiletAdeti += tamBiletAdeti;
                this.ToplamYarimBiletAdeti += yarimBiletAdeti;

                Console.WriteLine("Satış İşlemi Gerçekleştirildi.");
            }
            else
            {
                Console.WriteLine(BosKoltukAdetiGetir() + " adet bos koltuk mevcut. İşlem Gerçekleşmedi.");
            }
        }

        public void BiletIade(int tamBiletAdeti, int yarimBiletAdeti)
        {
            
            if (tamBiletAdeti <= this.ToplamTamBiletAdeti && yarimBiletAdeti <= ToplamYarimBiletAdeti)
            {
                this.ToplamTamBiletAdeti -= tamBiletAdeti;
                this.ToplamYarimBiletAdeti -= yarimBiletAdeti;

                Console.WriteLine("İade İşlemi Gerçekleştirildi.");
            }
            else
            {
                Console.WriteLine("Satılan bilet adetinden daha fazla iade işlemi yapılamaz.");
            }
        }

        //private float CiroHesapla()
        //{
        //    this.Ciro = this.TamBiletFiyati * this.ToplamTamBiletAdeti + this.YarimBiletFiyati * this.ToplamYarimBiletAdeti;
        //}

        public int BosKoltukAdetiGetir()
        {
            return this.Kapasite - this.ToplamTamBiletAdeti - this.ToplamYarimBiletAdeti;
        }

    }
}
