using Araba_Galeri_CF_EF.Context;
using Araba_Galeri_CF_EF.Sınıflar;

namespace Araba_Galeri_CF_EF
{
    public class Program
    {
        static ArabaDBContext arabaDbContext = new ArabaDBContext();
        static void Main(string[] args)
        {
            try
            {
                string kontrol = "D";
                string islem;
                int id;

                Listele();

                while (kontrol.ToUpper() == "D")
                {

                    Console.WriteLine("Eklemek için E,e, güncellemek için G,g, silmek için S,s  yaziniz:");
                    islem = Console.ReadLine();

                    while (islem.ToUpper() != "E" && islem.ToUpper() != "G" && islem.ToUpper() != "S")
                    {
                        Console.WriteLine("Geçersiz işlem!Tekrar giriniz:");
                        islem = Console.ReadLine();
                    }


                    switch (islem)
                    {
                        case "E":
                        case "e":

                            Araba araba = new Araba();
                            Console.WriteLine("Arabanın markasını giriniz:");
                            araba.Marka = Console.ReadLine();
                            Console.WriteLine("Arabanın yılını giriniz:");
                            araba.Yil = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Arabanın rengini giriniz:");
                            araba.Renk = Console.ReadLine();
                            Console.WriteLine("Arabanın fiyatını giriniz:");
                            araba.Fiyat = Convert.ToDouble(Console.ReadLine());

                            arabaDbContext.Arabalar.Add(araba);
                            arabaDbContext.SaveChanges();
                            Console.WriteLine("Başarıyla eklenmiştir.");
                            break;

                        case "G":
                        case "g":
                            Console.WriteLine("Güncellencek araba ID sini yazınız");
                            id = Convert.ToInt32(Console.ReadLine());

                            var guncellenecekAraba = arabaDbContext.Arabalar.Find(id);
                            if (guncellenecekAraba == null)
                                Console.WriteLine("Yazdığınız Id'ye ait araba yoktur");
                            else
                            {
                                Console.WriteLine("Arabanın markasını giriniz:");
                                guncellenecekAraba.Marka = Console.ReadLine();
                                Console.WriteLine("Arabanın yılını giriniz:");
                                guncellenecekAraba.Yil = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Arabanın rengini giriniz:");
                                guncellenecekAraba.Renk = Console.ReadLine();
                                Console.WriteLine("Arabanın fiyatını giriniz:");
                                guncellenecekAraba.Fiyat = Convert.ToDouble(Console.ReadLine());

                                arabaDbContext.SaveChanges();
                                Console.WriteLine("Başarıyla güncellenmiştir.");

                            }
                            break;

                        case "S":
                        case "s":

                            Console.WriteLine("Silinecek araba ID sini yazınız");
                            id = Convert.ToInt32(Console.ReadLine());

                            var silinecekAraba = arabaDbContext.Arabalar.Find(id);
                            if (silinecekAraba == null)
                                Console.WriteLine("Yazdığınız Id'ye ait araba yoktur");
                            else
                            {
                                arabaDbContext.Arabalar.Remove(silinecekAraba);
                                arabaDbContext.SaveChanges();
                                Console.WriteLine("Başarıyla silinmiştir.");

                            }
                            break;
                    }
                    Console.WriteLine("----------------------------------------------");
                    Listele();
                    Console.WriteLine("Devam etmek için D/d, çıkış için C/c yaziniz.");
                    kontrol = Console.ReadLine();

                    while (kontrol.ToUpper() != "D" &&
                       kontrol.ToUpper() != "C")
                    {
                        Console.WriteLine("Geçersiz karakter. Lütfen C/c/D/d giriniz!");
                        kontrol = Console.ReadLine();
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata " + ex.Message);
            }

        }

        static void Listele()
        {

            //Arabaları listeleyelim...
            foreach (var araba in arabaDbContext.Arabalar)
            {
                Console.WriteLine("ID: " + araba.Id + " Marka: " + araba.Marka + " Yıl: " + araba.Yil + " Renk: " + araba.Renk + " Fiyat: " + araba.Fiyat);
            }

        }
    }
}