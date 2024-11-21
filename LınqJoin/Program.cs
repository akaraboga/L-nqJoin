using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LınqJoin
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Yazar> yazarlar = new List<Yazar>//Yazarları listeye ekliyoruz
            {
                new Yazar {isim="Cengiz Aytmatov",Yazar_id=1},//Yazar_id yi linq join de kullanacağımız için kitap listesinde de aynı id yi vereceğiz
                new Yazar{isim="Sabahattin Ali",Yazar_id=2},
                new Yazar{isim="Frank Herbert",Yazar_id=3}
            };


            List<Kitap> kitaplar = new List<Kitap>//Kitapları listeye ekliyoruz
            {
                new Kitap{Kitap_id=1,Title="Beyaz Gemi",Yazar_id=1},
                new Kitap{Kitap_id=3,Title="İçimizdeki Şeytan",Yazar_id=2},
                new Kitap{Kitap_id=4,Title="Dune",Yazar_id = 3},
                new Kitap{Kitap_id=2,Title="Cemile",Yazar_id=1}//Yazar id si 1 olduğu için cengiz aytmatovla eşleştirecek
            };


            var birlestir = from Yazar in yazarlar
                            join Kitap in kitaplar on Yazar.Yazar_id equals Kitap.Yazar_id// Yazar.Yazar_id equals Kitap.Yazar_id.Yazardaki yazar_id ile kitapdaki yazar_id yi eşleştiriyoruz 
                            select new
                            {
                                kitapİsmi = Kitap.Title,//yeni olusturduğumuz propertylere değerlerini atıyoruz
                                Yazarisim = Yazar.isim


                            };


            foreach (var birlesenler in birlestir)//ekrana bastırma kısmı
            {
                Console.WriteLine("Kitap : {0} , Yazarı : {1}", birlesenler.kitapİsmi, birlesenler.Yazarisim);
                Console.WriteLine();
            }





            Console.ReadLine();
        }
    }
}
