using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Araba_Galeri_CF_EF.Sınıflar
{
    public class Araba
    {
        // bu sınıf veritabına olusturulan arabalar tablosuna tekabul eder
        // bu sınıf icerisine yazılan propertyler ise arabalar tablosu kolonlarına takabul eder

        // Primary key?

        public int Id { get; set; }

        public string Marka { get; set; }

        public int Yil { get; set; }

        public string Renk { get; set; }

        public double Fiyat { get; set; }

    }
}
