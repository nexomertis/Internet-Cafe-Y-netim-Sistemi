using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnternetCafe.Varliklar
{

    public class Bilgisayar
    {
        public int Id { get; set; }

        public string BilgisayarNo { get; set; }

        public bool Durum { get; set; }// true = açık/dolu, false = kapalı/boş

        public decimal SaatlikUcret {  get; set; }

        public DbSet<Bilgisayar> Bilgisayarlar { get; set; }
    }

}
