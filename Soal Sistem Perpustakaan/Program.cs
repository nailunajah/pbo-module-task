using System;
using System.Collections.Generic;
using System.Globalization;

namespace SistemPerpustakaan
{
    public abstract class Item
    {
        public string Judul {  get; set; }
        public int Tahun {  get; set; }

        public Item(string judul, int tahun)
        {
            Judul = judul;
            Tahun = tahun;
        }

        public virtual void Deskripsi()
        {
            Console.WriteLine($"Item: {Judul} ({Tahun})");
        }

        public void InfoItem()
        {
            Console.WriteLine($"Informasi Item: {Judul} - Tahun {Tahun}");
        }
    }

    public class Buku : Item
    {
        public string Penulis { get; set; }

        public Buku(string judul, int tahun, string penulis) : base(judul, tahun)
        {
            Penulis = penulis;
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"Buku: '{Judul}' oleh {Penulis} ({Tahun})");
        }

        public void CekPenulis()
        {
            Console.WriteLine($"Penulis buku '{Judul}' adalah {Penulis}");
        }
    }

    public class Majalah : Item
    {
        public int Edisi { get; set; }

        public Majalah(string judul, int tahun, int edisi) : base(judul, tahun)
        {
            Edisi = edisi;
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"Majalah: '{Judul}' edisi {Edisi} ({Tahun})");
        }

        public void InfoEdisi()
        {
            Console.WriteLine($"Majalah '{Judul}' edisi ke-{Edisi} ({Tahun})");
        }
    }

    public class Novel : Buku
    {
        public Novel(string judul, int tahun, string penulis) : base(judul, tahun, penulis)
        {
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"Novel: '{Judul}' oleh {Penulis} ({Tahun})");
        }

        public void BacaSinopsis()
        {
            Console.WriteLine($"Sinopsis Novel '{Judul}': Cerita berpusat pada Katniss Everdeen, seorang gadis 16 tahun dari Distrik 12 yang sukarela menggantikan adiknya dalam ajang tahunan brutal, di mana anak-anak remaja dipaksa bertarung hingga mati dalam siaran televisi.");
        }
    }

    public class Komik : Buku
    {
        public Komik(string judul, int tahun, string penulis) : base(judul, tahun, penulis)
        {
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"Komik: '{Judul}' karya {Penulis} ({Tahun})");
        }

        public void TampilkanIlustrasi()
        {
            Console.WriteLine($"Menampilkan ilustrasi dari komik '{Judul}' ...");
            Console.WriteLine("[Menampilkan gambar komik]");
        }
    }

    public class MajalahAnak : Majalah
    {
        public MajalahAnak(string judul, int tahun, int edisi) : base(judul, tahun, edisi)
        {
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"Majalah Anak: '{Judul}' edisi {Edisi} ({Tahun})");
        }

        public void KategoriAnak()
        {
            Console.WriteLine($"Kategori majalah '{Judul}' untuk anak:  Cerita fiksi, permainan, dan edukasi");
        }
    }

    public class MajalahTeknologi : Majalah
    {
        public MajalahTeknologi(string judul, int tahun, int edisi) : base(judul, tahun, edisi)
        {
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"Majalah Teknologi: '{Judul}' edisi {Edisi} ({Tahun})");
        }

        public void TopikTeknologi()
        {
            Console.WriteLine($"Topik teknologi majalah '{Judul}':  AI, Programming, Cyber Security");
        }
    }

    public class Perpustakaan
    {
        private List<Item> daftarItem;

        public Perpustakaan()
        {
            daftarItem = new List<Item>();
        }

        public void TambahItem(Item item)
        {
            daftarItem.Add(item);
            Console.WriteLine($"Item '{item.Judul}' berhasil ditambahkan ke perpustakaan");
        }

        public void DaftarItem()
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("DAFTAR SELURUH ITEM DI PERPUSTAKAAN");
            Console.WriteLine("===========================================");

            if (daftarItem.Count == 0)
            {
                Console.WriteLine("Item di perpustakaan kosong");
                return;
            }

            for (int i = 0; i < daftarItem.Count; i++)
            {
                Console.WriteLine($"\n[{i + 1}] ");
                daftarItem[i].Deskripsi();
                daftarItem[i].InfoItem();
            }
        }

        public int JumlahItem()
        {
            return daftarItem.Count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== SISTEM PERPUSTAKAAN =====");
            Console.WriteLine();

            Perpustakaan perpustakaan = new Perpustakaan();
            Novel novel1 = new Novel("The Hunger Games", 2008, "Suzanne Collins");
            Komik komik1 = new Komik("Neon Genesis Evangelion", 1994, "Yoshiyuki Sadamoto");
            MajalahAnak majalahanak1 = new MajalahAnak("Bobo", 2017, 14);
            MajalahTeknologi majalahteknologi1 = new MajalahTeknologi("PC Magazine", 1982, 1);

            perpustakaan.TambahItem(novel1);
            perpustakaan.TambahItem(komik1);
            perpustakaan.TambahItem(majalahanak1);
            perpustakaan.TambahItem(majalahteknologi1);

            perpustakaan.DaftarItem();

            Console.WriteLine("===========================================");
            Console.WriteLine("KATALOG PERPUSTAKAAN");
            Console.WriteLine("===========================================");

            Item[] items = { novel1, komik1, majalahanak1, majalahteknologi1 };
            foreach (Item item in items)
            {
                Console.WriteLine();
                item.Deskripsi();
                item.InfoItem();
            }

            Console.WriteLine("===========================================");
            Console.WriteLine("FITUR KHUSUS");
            Console.WriteLine("===========================================");

            Console.WriteLine("\n----- NOVEL -----");
            novel1.CekPenulis();
            novel1.BacaSinopsis();

            Console.WriteLine("\n----- KOMIK -----");
            komik1.CekPenulis();
            komik1.TampilkanIlustrasi();

            Console.WriteLine("\n----- MAJALAH ANAK -----");
            majalahanak1.InfoEdisi();
            majalahanak1.KategoriAnak();

            Console.WriteLine("\n----- MAJALAH TEKNOLOGI -----");
            majalahteknologi1.InfoEdisi();
            majalahteknologi1.TopikTeknologi();

            Console.WriteLine("===========================================");
            Console.WriteLine("Sistem perpustakaan siap digunakan.");
            Console.WriteLine("Total item: " + perpustakaan.JumlahItem());
            Console.WriteLine("===========================================");
        }
    }
}