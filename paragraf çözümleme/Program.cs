using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace paragraf_çözümleme
{
    class Program
    {
        static string oku(string konum)
        {
            string metin,dongu;

            //StreamReader DosyaOkuyucu = new StreamReader(konum, Encoding.GetEncoding("iso-8859-9"));
            FileStream DosyaOkuyucu = new FileStream(konum, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sw = new StreamReader(DosyaOkuyucu, Encoding.GetEncoding("iso-8859-9"));
            dongu = sw.ReadLine();
            metin = "";    
            while (dongu != null)
            {
                metin = metin + dongu + " ";
                dongu = sw.ReadLine();
            }
            
            //metin = DosyaOkuyucu.ReadToEnd();
            //TODO ev yapımı replace yazılacak
            for (int m = 0; m < metin.Length; m++)
            {
                if (metin[m] == '\r')
                {
                    metin = metin.Remove(m);
                    metin = metin.Insert(m, " ");
                }
            }
        
            DosyaOkuyucu.Close();
            metin = metin.Replace("-\r\n", "");
            metin = metin.Replace("\r\n", " ");

            //StreamReader oku = new StreamReader(konum, Encoding.GetEncoding("iso-8859-9"));
            //metin = oku.ReadToEnd();
            return metin;
        }
        static void Main(string[] args)
        {
            int harfSayisi = 0, boslukSayisi = 0, sayiSayisi = 0, cümleSayisi = 0;
            string Metin;
            //string yol;
            char[] harfler = { 'a', 'b', 'c', 'ç', 'd', 'e', 'f', 'g', 'ğ', 'h', 'ı', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'ö', 'p', 'r', 's', 'ş', 't', 'u', 'ü', 'v', 'y', 'z', 'w', 'x', 'q', 'A', 'B', 'C', 'Ç', 'D', 'E', 'F', 'G', 'Ğ', 'H', 'I', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'Ö', 'P', 'R', 'S', 'Ş', 'T', 'U', 'Ü', 'V', 'Y', 'Z', 'W', 'X', 'Q' };
            char[] sayılar = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            char[] cümleler = { '.', '?', '!' };

            //Console.Write("Lütfen okunacak olan dosyanın yolunu tam olarak giriniz: ");
            //yol = Console.ReadLine();
            //Metin = dosya(yol);
            Metin = oku("C:\\Users\\Fatih\\Desktop\\ornek.txt");
            //Metin = Metin.Replace("\r\n", " ");

            //for (int i = 0; i < Metin.Length; i++)
            //{
            //    if (Metin[i] = "\n\r")
            //    {
            //        Metin[i] = " ";
            //    }
            //}


            Console.WriteLine("Ulaşmak istediğiniz dosyanın içeriği:\n" + Metin);

            int[] harf_sayisi = new int[harfler.Length];
            Boolean yazi;
            for (int i = 0; i < Metin.Length; i++)
            {
                
                if (Metin[i] == ' ')
                {
                    boslukSayisi++;

                    //for (int k = 0; k < sayılar.Length; k++)
                    //{
                    //    if (Metin[i + 1] == sayılar[k] || Metin[0] == sayılar[k])
                    //    {
                    //        sayiSayisi++;
                    //    }
                    //}
                }

                yazi = char.IsLetter(Metin[i]); 

                if(yazi==true)
                {
                    harfSayisi++;
                }

                yazi = char.IsNumber(Metin[i]);

                if (yazi == true)
                {
                    sayiSayisi++;
                }

                //for (int j = 0; j < harfler.Length; j++)
                //{

                //    if (Metin[i] == harfler[j])
                //    {
                //        harfSayisi++;
                //        harf_sayisi[j]++;
                //    }
                //}

                //for (int c = 0; c < cümleler.Length; c++)
                //{

                //    if (Metin[i] == cümleler[c])
                //    {
                //        cümleSayisi++;
                //    }
                //}
            }
            Console.WriteLine("Paragrafta bulunan kelime sayısı: " + (boslukSayisi + 1));
            Console.WriteLine("Paragrafta bulunan harf sayısı: " + harfSayisi);
            Console.WriteLine("Paragrafta bulunan sayı sayısı: " + sayiSayisi);
            Console.WriteLine("Paragrafta bulunan cümle sayısı: " + cümleSayisi);

            //for (int i = 0; i < harf_sayisi.Length - 32; i++)
            //{
            //    Console.WriteLine(harfler[i] + " harfinden: {0} tane", harf_sayisi[i] + harf_sayisi[i + 32]);
            //}
            Console.ReadKey();
        }
    }
}




