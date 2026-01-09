using InnternetCafe.Varliklar;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetCafe.VeriKatmani
{
    public  class KafedbContext : DbContext
    {
      public KafedbContext(DbContextOptions<KafedbContext> options) : base(options)
        {

        }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Bilgisayar> Bilgisayarlar { get; set; }
        public DbSet<Oturum> Oturumlar { get; set; }
    }
}
