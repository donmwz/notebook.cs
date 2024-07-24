using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Merhaba! Not Defteri Oluşturma aracına hoş geldiniz.");
        Console.WriteLine("1- Yeni Not Defteri Oluştur \n2- Mevcut Not Defterleri \n3- Mevcut Not Defterlerini Düzenle \n4- Çıkış");
        int istem = Convert.ToInt32(Console.ReadLine());

        if (istem == 1 || istem == 2 || istem == 3 || istem == 4)
        {
            if (istem == 1)
            {
                Console.WriteLine("Yeni Not Defteri Oluşturuluyor...");
                Console.WriteLine("Yeni Not Defterinin Adı: ");
                var defter_adi = Console.ReadLine();
                using (StreamWriter sw = File.CreateText(defter_adi + ".txt"))
                {
                    // Dosya oluşturuluyor.
                }
                Console.WriteLine($"{defter_adi}, için içeriğini girin: ");
                var defter_icerik = Console.ReadLine();
                using (StreamWriter sw = File.AppendText(defter_adi + ".txt"))
                {
                    sw.WriteLine(defter_icerik);
                    Console.WriteLine("Değişikler başarıyla uygulandı! Dosya kaydedildi.");
                }
            }

            if (istem == 2)
            {
                Console.WriteLine("Mevcut Not Defterleri Gösteriliyor...");
                string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");
                foreach (string file in files)
                {
                    Console.WriteLine(Path.GetFileName(file));
                }
            }

            if (istem == 3)
            {
                Console.WriteLine("Mevcut Not Defterlerini Düzenliyor...");
                Console.WriteLine("Düzenlemek istediğiniz not defterinin adını girin: ");
                var defter_adi = Console.ReadLine();
                if (File.Exists(defter_adi + ".txt"))
                {
                    Console.WriteLine("Mevcut içeriği:");
                    string content = File.ReadAllText(defter_adi + ".txt");
                    Console.WriteLine(content);

                    Console.WriteLine("Yeni içeriği girin: ");
                    var yeni_icerik = Console.ReadLine();
                    using (StreamWriter sw = File.AppendText(defter_adi + ".txt"))
                    {
                        sw.WriteLine(yeni_icerik);
                        Console.WriteLine("Değişikler başarıyla uygulandı! Dosya kaydedildi.");
                    }
                }
                else
                {
                    Console.WriteLine("Belirtilen adla bir dosya bulunamadı.");
                }
            }

            if (istem == 4)
            {
                Console.WriteLine("Çıkış Yapılıyor...");
                return; 
            }
        }
        else
        {
            Console.WriteLine("Geçersiz İşlem! Lütfen tekrar deneyiniz.");
        }
    }
}
