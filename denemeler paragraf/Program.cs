
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace denemeler_paragraf
{
    class Program
    {
        static void Main(string[] args)
        {
            int harfSayisi = 0, boslukSayisi = 0, sayiSayisi = 0, cümleSayisi = 0;
            string yol;
            char[] harfler = { 'a', 'b', 'c', 'ç', 'd', 'e', 'f', 'g', 'ğ', 'h', 'ı', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'ö', 'p', 'r', 's', 'ş', 't', 'u', 'ü', 'v', 'y', 'z', 'w', 'x', 'q', 'A', 'B', 'C', 'Ç', 'D', 'E', 'F', 'G', 'Ğ', 'H', 'I', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'Ö', 'P', 'R', 'S', 'Ş', 'T', 'U', 'Ü', 'V', 'Y', 'Z', 'W', 'X', 'Q' };
            char[] sayılar = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            char[] cümleler = { '.', '?', '!' };

            // okunacak dosyanın yolunu parametre olarak alan ve dosyanın içeriğini string olarak dönen bir fonksiyon yazıp kullanılacak

            string DosyaKonumu = "C:\\Users\\Fatih\\Desktop\\ornek.txt";
            StreamReader DosyaOkuyucu = new StreamReader(DosyaKonumu, Encoding.GetEncoding("iso-8859-9"));
            string Metin = DosyaOkuyucu.ReadToEnd();
            Console.Write("Lütfen okunacak olan dosyanın yolunu tam olarak giriniz: ");
            yol = Console.ReadLine();
            //StreamReader oku = new StreamReader(yol, Encoding.GetEncoding("iso-8859-9"));
            //cumle = oku.ReadToEnd();
            DosyaOkuyucu.Close();

            Console.WriteLine("Ulaşmak istediğiniz dosyanın içeriği:\n" + Metin);

            int[] harf_sayisi = new int[harfler.Length];

            for (int i = 0; i < Metin.Length; i++)
            {

                if (Metin[i] == ' ' || Metin[i] == '\n')
                {
                    boslukSayisi++;

                    for (int k = 0; k < sayılar.Length; k++)
                    {
                        if (Metin[i + 1] == sayılar[k])
                        {
                            sayiSayisi++;
                        }
                    }
                }

                for (int k = 0; k < sayılar.Length; k++)
                { //TODO metindeki tüm \n ler temizlenecek
                    if (Metin[i] == '\n' && Metin[i + 1] == sayılar[k])
                    {
                        sayiSayisi++;
                    }
                }

                for (int j = 0; j < harfler.Length; j++)
                {

                    if (Metin[i] == harfler[j])
                    {
                        harfSayisi++;
                        harf_sayisi[j]++;
                    }
                }

                for (int c = 0; c < cümleler.Length; c++)
                {

                    if (Metin[i] == cümleler[c])
                    {
                        cümleSayisi++;
                    }
                }
            }
            Console.WriteLine("Paragrafta bulunan kelime sayısı: " + (boslukSayisi + 1));
            Console.WriteLine("Paragrafta bulunan harf sayısı: " + harfSayisi);
            Console.WriteLine("Paragrafta bulunan sayı sayısı: " + sayiSayisi);
            Console.WriteLine("Paragrafta bulunan cümle sayısı: " + cümleSayisi);

            for (int i = 0; i < harf_sayisi.Length - 32; i++)
            {
                Console.WriteLine(harfler[i] + " harfinden: {0} tane", harf_sayisi[i] + harf_sayisi[i + 32]);
            }
            Console.ReadKey();
        }
    }
}
