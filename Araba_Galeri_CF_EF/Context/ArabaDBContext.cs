using Araba_Galeri_CF_EF.Sınıflar;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Araba_Galeri_CF_EF.Context
{
    public class ArabaDBContext : DbContext  // baglam sınıfı
    {
        // Connection string = baglantı cumlesi vb bilgileri

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.;database=ArabaDB;trusted_connection=true");
            // baglantı cumlesi
        }
        // Tablolar?
        public DbSet<Araba> Arabalar { get; set; }
    }
}
