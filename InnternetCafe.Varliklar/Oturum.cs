using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnternetCafe.Varliklar
{
    public class Oturum
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }
        public int BilgisayarId { get; set; }
        public Bilgisayar Bilgisayar { get; set; }
        public DateTime BaslangicZamanı { get; set; }
        public DateTime? BitisZamani { get; set; }
        public decimal? ToplamUcret { get; set; }
    }
}
