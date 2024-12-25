namespace MehmetCanTuranÖdevAlgoritmaSınıf1Şube1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Kaç öğrenci kaydetmek istiyorsunuz");
                int kayıt = int.Parse(Console.ReadLine());
                string[,] dizi = new string[kayıt + 1, 7];
                dizi[0, 0] = "Numara";
                dizi[0, 1] = "İsim";
                dizi[0, 2] = "Soyad";
                dizi[0, 3] = "Vize Notu";
                dizi[0, 4] = "Final Notu";
                dizi[0, 5] = "Ortalama Notu";
                dizi[0, 6] = "Harf Notu";
                double toplamOrtalama = 0;
                int maxNot = int.MinValue;
                int minNot = int.MaxValue;

                for (int i = 1; i <= kayıt; i++)
                {
                    Console.WriteLine($"{i}. Kişinin ismini giriniz:");
                    string isim = Console.ReadLine();

                    Console.WriteLine($"{i}. Kişinin soyadını giriniz:");
                    string soyad = Console.ReadLine();

                    Console.WriteLine($"{i}. Kişinin öğrenci numarasını giriniz:");
                    long no = long.Parse(Console.ReadLine());

                    int not1;
                    do
                    {
                        Console.WriteLine($"{i}. Kişinin vize notunu giriniz (0-100):");
                        not1 = int.Parse(Console.ReadLine());
                        if (not1 < 0 || not1 > 100)
                            Console.WriteLine("Lütfen 0 ile 100 arasında bir değer giriniz.");
                    } while (not1 < 0 || not1 > 100);

                    int not2;
                    do
                    {
                        Console.WriteLine($"{i}. Kişinin final notunu giriniz (0-100):");
                        not2 = int.Parse(Console.ReadLine());
                        if (not2 < 0 || not2 > 100)
                            Console.WriteLine("Lütfen 0 ile 100 arasında bir değer giriniz.");
                    } while (not2 < 0 || not2 > 100);

                    double ortalama = not1 * 0.4 + not2 * 0.6;
                    toplamOrtalama += ortalama;

                    maxNot = Math.Max(maxNot, Math.Max(not1, not2));
                    minNot = Math.Min(minNot, Math.Min(not1, not2));

                    string harfnotu = ortalama >= 85 ? "AA" :
                                      ortalama >= 75 ? "BA" :
                                      ortalama >= 60 ? "BB" :
                                      ortalama >= 50 ? "CB" :
                                      ortalama >= 40 ? "CC" :
                                      ortalama >= 30 ? "DC" :
                                      ortalama >= 20 ? "DD" :
                                      ortalama >= 10 ? "FD" : "FF";

                    dizi[i, 0] = no.ToString();
                    dizi[i, 1] = isim;
                    dizi[i, 2] = soyad;
                    dizi[i, 3] = not1.ToString();
                    dizi[i, 4] = not2.ToString();
                    dizi[i, 5] = ortalama.ToString("0.00");
                    dizi[i, 6] = harfnotu;
                }

                double sınıfOrtalaması = toplamOrtalama / kayıt;

                Console.WriteLine("\nGirilen Öğrenci Bilgileri:");
                for (int i = 0; i <= kayıt; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        Console.Write(dizi[i, j].PadRight(15));
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("\nSınıf Bilgileri:");
                Console.WriteLine($"Sınıf Ortalaması: {sınıfOrtalaması:0.00}");
                Console.WriteLine($"En Yüksek Not: {maxNot}");
                Console.WriteLine($"En Düşük Not: {minNot}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Yanlış formatta giriş yaptınız.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Lütfen geçerli bir değer giriniz.");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Boş bir giriş yaptınız. Lütfen bir değer giriniz.");
            }
            catch (Exception)
            {
                Console.WriteLine("Beklenmeyen bir hata oluştu.");
            }
        }
    }
}
