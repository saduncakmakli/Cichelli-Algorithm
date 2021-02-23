using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectHash
{
    internal partial class Controller
    {
        internal Controller()
        {
            VeriGirisiYap(out List<string> kelimeler);
            BastaSondakiHarfleriBul(in kelimeler, out Harf[] alfabe, out List<char> gecenHarfler);
            KelimelerinHarfDegerToplamınıBul(in kelimeler, in alfabe, in gecenHarfler, out Veri[] veriler);
            KelimeleriDegereGöreSırala(in kelimeler, ref veriler);
            KelimelerinKontrolEttiğiHarfleriBul(in alfabe, ref veriler);
            YenidenSırala(in alfabe, ref veriler);
            PerfectHash(in alfabe, ref veriler, in gecenHarfler);

            Console.ReadKey();
        }

        public struct Veri
        {
            public string kelime;
            public int bsdegeri;
            public int harf1;
            public int harf2;
            public int hashcode;
            public int ilkharf;
            public int sonharf;
        }

        public struct Harf
        {
            public char harf_char;
            public ushort basta_sonda_kac_adet;
            public int sonrakiHarf; //bağlantı henüz yapılmadı
            public int oncekiHarf;  //bağlantı henüz yapılmadı
            public int harf_anahtar_degeri;
        }

        private Harf[] CreateAlphabet()
        {
            Harf[] harfler = new Harf[33];
            for (int x = 0; x < 33; x++)
            {
                harfler[x].basta_sonda_kac_adet = 0;
                harfler[x].harf_anahtar_degeri = 0;
                harfler[x].oncekiHarf = 32;
                harfler[x].sonrakiHarf = 32;
                harfler[x].harf_char = Alphabet_LetterCode_To_Letter(x);
            }
            return harfler;
        }

        private Veri[] CreateVeriler(int length)
        {
            Veri[] veriler = new Veri[length];
            for (int x = 0; x < length; x++)
            {
                veriler[x].harf1 = 32;
                veriler[x].harf2 = 32;
                veriler[x].hashcode = -1;
            }
            return veriler;

        }

        private void VeriGirisiYap(out List<string> veriler)
        {
            Console.BackgroundColor = ConsoleColor.Black;

            ConsoleTypewriteLine("PERFECT HASHING\nCichelli'nin Algoritması \n", ConsoleColor.Yellow);
            ConsoleTypewriteLine("Programlayan\nMuhammed Sadun Çakmaklı", ConsoleColor.Blue);
            ConsoleTypewriteLine("1030520673\n", ConsoleColor.Blue, Console.CursorLeft + 6, Console.CursorTop);

            veriler = new List<string>();
            bool isFirst = true;
            string tempString;
            ConsoleKey tempKey;
            while (true)
            {
                if (isFirst == true)
                {
                    ConsoleTypewrite("Lütfen algoritmaya eklenecek kelimeyi girin ve onaylamak için ", ConsoleColor.Yellow);
                    ConsoleTypewrite("ENTER", ConsoleColor.Red);
                    ConsoleTypewriteLine(" tuşuna basınız.", ConsoleColor.Yellow);



                    ConsoleTypewrite("Kelimeleri girdikten sonra algoritmayı çalıştırmak için ");
                    ConsoleTypewrite("ESC", ConsoleColor.Red);
                    ConsoleTypewriteLine(" tuşuna basınız.", ConsoleColor.Yellow);
                    isFirst = false;
                }
                ConsoleTypewrite("Kelime: ", ConsoleColor.Yellow);
                Console.ForegroundColor = ConsoleColor.Blue;
                if (isFirst == true)
                {
                    veriler.Add(Console.ReadLine());
                }
                else
                {
                    tempKey = Console.ReadKey(false).Key;
                    if (tempKey == ConsoleKey.Escape)
                    {
                        ConsoleClear(Console.CursorLeft - 9, Console.CursorTop, 9, 1);
                        break;
                    }
                    else
                    {
                        tempString = tempKey.ToString() + Console.ReadLine();
                        veriler.Add(tempString);
                    }
                }
            }

            ConsoleTypewriteLine(veriler.Count.ToString() + " kelime eklendi.\nEklenen Kelimeler", ConsoleColor.Yellow);

            //Kelimelerin büyük harf yapılması.
            for (int sayac = 0; sayac < veriler.Count; sayac++)
            {
                veriler[sayac] = veriler[sayac].ToUpper();
            }

            //Kelimelerin ekrana yazılması.
            foreach (string x in veriler)
            {
                ConsoleTypewriteLine(x, ConsoleColor.Magenta);
            }
            Console.WriteLine();
        }

        public static char StringIlkHarfiniBul(in string kelime)
        {
            return kelime[0];
        }

        public static char StringSonHarfiniBul(in string kelime)
        {
            return kelime[kelime.Length - 1];
        }

        public static char Alphabet_LetterCode_To_Letter(in int LetterCode)
        {
            switch (LetterCode)
            {
                case 0: return 'A';
                case 1: return 'B';
                case 2: return 'C';
                case 3: return 'Ç';
                case 4: return 'D';
                case 5: return 'E';
                case 6: return 'F';
                case 7: return 'G';
                case 8: return 'Ğ';
                case 9: return 'H';
                case 10: return 'I';
                case 11: return 'İ';
                case 12: return 'J';
                case 13: return 'K';
                case 14: return 'L';
                case 15: return 'M';
                case 16: return 'N';
                case 17: return 'O';
                case 18: return 'Ö';
                case 19: return 'P';
                case 20: return 'Q';
                case 21: return 'R';
                case 22: return 'S';
                case 23: return 'Ş';
                case 24: return 'T';
                case 25: return 'U';
                case 26: return 'Ü';
                case 27: return 'V';
                case 28: return 'W';
                case 29: return 'X';
                case 30: return 'Y';
                case 31: return 'Z';
                case 32: return '?';
                default: return '*';
            }
        }

        public static int Alphabet_Letter_To_LetterCode(in char Letter)
        {
            switch (Letter)
            {
                case 'A': return 0;
                case 'B': return 1;
                case 'C': return 2;
                case 'Ç': return 3;
                case 'D': return 4;
                case 'E': return 5;
                case 'F': return 6;
                case 'G': return 7;
                case 'Ğ': return 8;
                case 'H': return 9;
                case 'I': return 10;
                case 'İ': return 11;
                case 'J': return 12;
                case 'K': return 13;
                case 'L': return 14;
                case 'M': return 15;
                case 'N': return 16;
                case 'O': return 17;
                case 'Ö': return 18;
                case 'P': return 19;
                case 'Q': return 20;
                case 'R': return 21;
                case 'S': return 22;
                case 'Ş': return 23;
                case 'T': return 24;
                case 'U': return 25;
                case 'Ü': return 26;
                case 'V': return 27;
                case 'W': return 28;
                case 'X': return 29;
                case 'Y': return 30;
                case 'Z': return 31;
                case '?': return 32;
                default: return -1;
            }
        }

        private void BastaSondakiHarfleriBul(in List<string> kelimeler, out Harf[] alfabe, out List<char> gecenHarfler)
        {
            alfabe = CreateAlphabet();
            gecenHarfler = new List<char>();
            //Bütün verileri kontrol et
            foreach (string kelime in kelimeler)
            {
                char ilkharf = StringIlkHarfiniBul(kelime);
                char sonharf = StringSonHarfiniBul(kelime);

                //Kelimenin ilk harfi geçen harf listesinde yoksa
                if (!gecenHarfler.Contains(ilkharf))
                {
                    gecenHarfler.Add(ilkharf); //Gecen harfi listeye ekle
                    alfabe[Alphabet_Letter_To_LetterCode(ilkharf)].basta_sonda_kac_adet++;
                }

                //Kelimenin ilk harfi geçen harf listesinde varsa
                else
                {
                    alfabe[Alphabet_Letter_To_LetterCode(ilkharf)].basta_sonda_kac_adet++;
                }

                //Kelimenin son harfi geçen harf listesinde yoksa
                if (!gecenHarfler.Contains(sonharf))
                {
                    gecenHarfler.Add(sonharf); //Gecen harfi listeye ekle
                    alfabe[Alphabet_Letter_To_LetterCode(sonharf)].basta_sonda_kac_adet++;
                }

                //Kelimenin son harfi geçen harf listesinde varsa
                else
                {
                    alfabe[Alphabet_Letter_To_LetterCode(sonharf)].basta_sonda_kac_adet++;
                }
            }

            //Başta ve sonda geçen harflerin yazılması
            ConsoleTypewriteLine("Başta ve sonda geçen harfler", ConsoleColor.Yellow);
            foreach (char harf in gecenHarfler)
            {
                ConsoleTypewrite(harf + "-", ConsoleColor.Blue);
                ConsoleTypewriteLine(alfabe[Alphabet_Letter_To_LetterCode(harf)].basta_sonda_kac_adet, ConsoleColor.DarkRed);
            }
        }

        private void KelimelerinHarfDegerToplamınıBul(in List<string> kelimeler, in Harf[] alfabe, in List<char> gecenHarfler, out Veri[] veriler)
        {
            veriler = CreateVeriler(kelimeler.Count);

            int s = 0;
            foreach (string kelime in kelimeler)
            {
                char ilkharf = StringIlkHarfiniBul(kelime);
                char sonharf = StringSonHarfiniBul(kelime);

                veriler[s].kelime = kelime;
                veriler[s].ilkharf = Alphabet_Letter_To_LetterCode(StringIlkHarfiniBul(kelime));
                veriler[s].sonharf = Alphabet_Letter_To_LetterCode(StringSonHarfiniBul(kelime));

                veriler[s].bsdegeri = alfabe[Alphabet_Letter_To_LetterCode(ilkharf)].basta_sonda_kac_adet + alfabe[Alphabet_Letter_To_LetterCode(sonharf)].basta_sonda_kac_adet;
                s++;
            }

            ConsoleTypewriteLine("\nKelimelerin başındaki ve sonundaki harflerin toplam kullanım sayısı", ConsoleColor.Yellow);
            for (int x = 0; x < kelimeler.Count; x++)
            {
                ConsoleTypewrite(veriler[x].bsdegeri + " - ", ConsoleColor.Red);
                ConsoleTypewriteLine(veriler[x].kelime, ConsoleColor.Blue);
            }
            
        }

        private void KelimeleriDegereGöreSırala(in List<string> kelimeler, ref Veri[] veriler)
        {
            Veri temp_veri;
            bool sıralı_mı = false;

            //BUBLE SORT SIRALAMA ALG.
            while (!sıralı_mı)
            {
                sıralı_mı = true;
                for (int x = 0; x < kelimeler.Count - 1; x++)
                {
                    if (veriler[x].bsdegeri < veriler[x + 1].bsdegeri)
                    {
                        sıralı_mı = false;
                        temp_veri = veriler[x];

                        veriler[x] = veriler[x + 1];

                        veriler[x + 1] = temp_veri;
                    }
                }
            }

            ConsoleTypewriteLine("\nKelimelerin baştaki ve sondaki harf değerine göre sıralaması", ConsoleColor.Yellow);
            for (int x = 0; x < kelimeler.Count; x++)
            {
                ConsoleTypewrite(veriler[x].bsdegeri + " - ", ConsoleColor.DarkCyan);
                ConsoleTypewriteLine(veriler[x].kelime, ConsoleColor.DarkCyan);
            }
        }

        private void KelimelerinKontrolEttiğiHarfleriBul(in Harf[] alfabe, ref Veri[] veriler)
        {
            char ilkharf;
            int ilkharf_code;
            char sonharf;
            int sonharf_code;

            bool[] harf_var_mı = new bool[32];
            for (int x = 0; x < veriler.Length; x++)
            {
                ilkharf = StringIlkHarfiniBul(veriler[x].kelime);
                ilkharf_code = Alphabet_Letter_To_LetterCode(ilkharf);

                sonharf = StringSonHarfiniBul(veriler[x].kelime);
                sonharf_code = Alphabet_Letter_To_LetterCode(sonharf);

                if (x == 0)
                {
                    veriler[x].harf1 = ilkharf_code;
                    harf_var_mı[ilkharf_code] = true;

                    veriler[x].harf2 = sonharf_code;
                    harf_var_mı[sonharf_code] = true;
                }
                else
                {
                    //Kelimenin ilk harfi daha önceden geçmemişse
                    if (!harf_var_mı[ilkharf_code])
                    {
                        veriler[x].harf1 = ilkharf_code;
                        harf_var_mı[ilkharf_code] = true;
                    }
                    //Kelimenin son harfi daha önceden geçmemişse
                    if (!harf_var_mı[sonharf_code])
                    {
                        veriler[x].harf1 = sonharf_code;
                        harf_var_mı[sonharf_code] = true;
                    }
                }
            }
            
            Console.WriteLine();
            ConsoleTypewriteLine("Kelimelerin kontrol ettiği harfler.", ConsoleColor.Yellow);
            for (int x = 0; x < veriler.Length; x++)
            {
                ConsoleTypewrite(veriler[x].kelime, ConsoleColor.Green);
                ConsoleTypewrite(" - ", ConsoleColor.DarkGreen);
                ConsoleTypewrite(alfabe[veriler[x].harf1].harf_char, ConsoleColor.Red);
                ConsoleTypewrite(" - ", ConsoleColor.DarkGreen);
                ConsoleTypewriteLine(alfabe[veriler[x].harf2].harf_char, ConsoleColor.Red);
            }
        }

        private void YenidenSırala(in Harf[] alfabe, ref Veri[] veriler)
        {
            bool harf_var_mı;
            char harfilk;
            char harfson;
            for (int x = 0; x < veriler.Length; x++)
            {
                harf_var_mı = false;
                if (veriler[x].harf1 != 32) harf_var_mı = true;
                if (veriler[x].harf2 != 32) harf_var_mı = true;

                //Kelimenin kontrol ettiği harf yok.
                if (harf_var_mı == false)
                {
                    harfilk = StringIlkHarfiniBul(veriler[x].kelime);
                    harfson = StringSonHarfiniBul(veriler[x].kelime);
                    bool harfilk_control = false;
                    bool harfson_control = false;

                    for (int y = 0; y < x; y++)
                    {
                        //Kontrol ettiği harf olmayan kelimenin ilk harfini bu kelime mi kontrol ediyor?
                        if ((veriler[y].harf1 == Alphabet_Letter_To_LetterCode(harfilk)) || (veriler[y].harf2 == Alphabet_Letter_To_LetterCode(harfilk)))
                        {
                            harfilk_control = true;
                        }

                        //Kontrol ettiği harf olmayan kelimenin son harfini bu kelime mi kontrol ediyor?
                        if ((veriler[y].harf1 == Alphabet_Letter_To_LetterCode(harfson)) || (veriler[y].harf2 == Alphabet_Letter_To_LetterCode(harfson)))
                        {
                            harfson_control = true;
                        }

                        Veri tempVeri;
                        //İlk ve Son harfi kontrol eden kelimeler bulundu ise.
                        if (harfilk_control&&harfson_control)
                        {
                            for (int z = x; z > y + 1; z--)
                            {
                                tempVeri = veriler[z];
                                veriler[z] = veriler[z - 1];
                                veriler[z - 1] = tempVeri;
                            }
                        }
                    }

                }
            }

            Console.WriteLine();
            ConsoleTypewriteLine("Kelimenin ilk ve son harfi daha önce geçiyorsa sıralamada son geçtiği yerin altına alındı.", ConsoleColor.Yellow);
            for (int x = 0; x < veriler.Length; x++)
            {
                ConsoleTypewrite(veriler[x].kelime, ConsoleColor.Green);
                ConsoleTypewrite(" - ", ConsoleColor.DarkGreen);
                ConsoleTypewrite(alfabe[veriler[x].harf1].harf_char, ConsoleColor.Red);
                ConsoleTypewrite(" - ", ConsoleColor.DarkGreen);
                ConsoleTypewriteLine(alfabe[veriler[x].harf2].harf_char, ConsoleColor.Red);
            }
        }

        private bool ConflictBul(in Harf[] alfabe, ref Veri[] veriler, ref int conflict1, ref int conflict2, int İlkKacElemanKontrolEdilecek)
        {
            HashHesapla(in alfabe, ref veriler, veriler.Length);

            conflict1 = -1;
            conflict2 = -1;
            bool hashcontrol = true;
            for (int x = 0; x < İlkKacElemanKontrolEdilecek; x++)
            {
                for (int y = 0; y < İlkKacElemanKontrolEdilecek; y++)
                {
                    if (x != y)
                    {
                        if (veriler[x].hashcode == veriler[y].hashcode)
                        {
                            hashcontrol = false;
                            conflict1 = x;
                            conflict2 = y;
                            return hashcontrol;
                        }
                    }
                }
            }

            return hashcontrol;
        }

        private void HashHesapla(in Harf[] alfabe, ref Veri[] veriler, int İlkKacElemanKontrolEdilecek)
        {
            int mod = veriler.Length;

            for (int x = 0; x < İlkKacElemanKontrolEdilecek; x++)
            {
                //Formul -> HASH DEGERI = (KELİME_UZUNLUK + B ANAHTAR + S ANAHTAR)MOD VERİSAYISI
                veriler[x].hashcode = ((veriler[x].kelime.Length + alfabe[veriler[x].ilkharf].harf_anahtar_degeri + alfabe[veriler[x].sonharf].harf_anahtar_degeri) % mod); //HASH HESABI
            }
        }

        private void PerfectHash(in Harf[] alfabe, ref Veri[] veriler, in List<char> gecenHarfler)
        {
            //Formul -> HASH DEGERI = (KELİME_UZUNLUK + B ANAHTAR + S ANAHTAR) MOD VERİSAYISI
            //HARF ANAHTAR DEGERİ MAX 4 OLABİLİR.

            int mod = veriler.Length;
            int conflict1 = -1;
            int conflict2 = -1;

            for (int x = 0; x < veriler.Length-1; x++)
            {
                //DEBUG conflict arama öncesi
                HashHesapla(in alfabe, ref veriler, veriler.Length);
                Console.WriteLine();
                for (int s = 0; s < x + 2; s++)
                {
                    ConsoleTypewrite(veriler[s].hashcode + " ", ConsoleColor.Red);
                    ConsoleTypewriteLine(veriler[s].kelime, ConsoleColor.Magenta);
                }

                for (int s = x+2; s < veriler.Length; s++)
                {
                    ConsoleTypewrite(veriler[s].hashcode + " ", ConsoleColor.DarkRed);
                    ConsoleTypewriteLine(veriler[s].kelime, ConsoleColor.DarkMagenta);
                }

                for (int s = 0; s < gecenHarfler.Count; s++)
                {
                    ConsoleTypewrite(alfabe[Alphabet_Letter_To_LetterCode(gecenHarfler[s])].harf_char + " ", ConsoleColor.Red);
                    ConsoleTypewriteLine(alfabe[Alphabet_Letter_To_LetterCode(gecenHarfler[s])].harf_anahtar_degeri, ConsoleColor.Blue);
                }

                while (true)
                {
                    if (!ConflictBul(in alfabe, ref veriler, ref conflict1, ref conflict2, x + 2))
                    {
                        Console.WriteLine("\n" + conflict1 + " - " + conflict2);
                        AnahtarDegeriArttır(in alfabe, ref veriler, conflict2);

                        //DEBUG conflict arama öncesi
                        HashHesapla(in alfabe, ref veriler, veriler.Length);
                        Console.WriteLine();
                        for (int s = 0; s < x + 2; s++)
                        {
                            ConsoleTypewrite(veriler[s].hashcode + " ", ConsoleColor.Red);
                            ConsoleTypewriteLine(veriler[s].kelime, ConsoleColor.Magenta);
                        }

                        for (int s = x + 2; s < veriler.Length; s++)
                        {
                            ConsoleTypewrite(veriler[s].hashcode + " ", ConsoleColor.DarkRed);
                            ConsoleTypewriteLine(veriler[s].kelime, ConsoleColor.DarkMagenta);
                        }

                        for (int s = 0; s < gecenHarfler.Count; s++)
                        {
                            ConsoleTypewrite(alfabe[Alphabet_Letter_To_LetterCode(gecenHarfler[s])].harf_char + " ", ConsoleColor.Red);
                            ConsoleTypewriteLine(alfabe[Alphabet_Letter_To_LetterCode(gecenHarfler[s])].harf_anahtar_degeri, ConsoleColor.Blue);
                        }

                    }
                    //Çakışma yoksa
                    else
                        break;
                }
            }
        }

        private void AnahtarDegeriArttır (in Harf[] alfabe, ref Veri[] veriler, int Kacıncıveri)
        {
            //Çakışan kelimelerden sıralaması aşağıda olanın herhangi bir anahtar değeri varsa.
            if (veriler[Kacıncıveri].harf1 != 32)
            {
                //Çakışan kelimelerden sıralaması aşağıda olanın harf1'inin anahtar değeri 4'den küçükse.
                if (alfabe[veriler[Kacıncıveri].harf1].harf_anahtar_degeri < 4)
                {
                    alfabe[veriler[Kacıncıveri].harf1].harf_anahtar_degeri++;
                }

                else if (veriler[Kacıncıveri].harf2 != 32)
                {
                    //Çakışan kelimelerden sıralaması aşağıda olanın harf1'inin anahtar değeri  4'den büyük ama harf2si var ve 4den küçükse.
                    if (alfabe[veriler[Kacıncıveri].harf2].harf_anahtar_degeri < 4)
                    {
                        alfabe[veriler[Kacıncıveri].harf2].harf_anahtar_degeri++;
                    }
                    else
                    {
                        //Bu kelimenin harf2sini sıfırla ve
                        alfabe[veriler[Kacıncıveri].harf2].harf_anahtar_degeri = 0;

                        //Bir önceki kelimenin kontrol ettiği harfi arttır.
                        AnahtarDegeriArttır(in alfabe, ref veriler, (Kacıncıveri-1));
                    }
                }

                //Çakışan kelimelerden sıralaması aşağıda olanın harf1'inin anahtar değeri 4'den büyükse ve ikinci kontrol ettiği harf yoksa.
                else
                {
                    //Bu kelimenin harf1sini sıfırla ve
                    alfabe[veriler[Kacıncıveri].harf1].harf_anahtar_degeri = 0;

                    //Bir önceki kelimenin kontrol ettiği harfi arttır.
                    AnahtarDegeriArttır(in alfabe, ref veriler, (Kacıncıveri - 1));
                }
            }
            //Çakışan kelimenin anahtar kelimesi yoksa!
            else
            {
                //Bir önceki kelimenin kontrol ettiği harfi arttır.
                AnahtarDegeriArttır(in alfabe, ref veriler, (Kacıncıveri - 1));
            }
        }
    }
}
