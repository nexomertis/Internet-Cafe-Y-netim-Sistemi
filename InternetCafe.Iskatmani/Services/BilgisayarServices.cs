using InnternetCafe.Varliklar;
using InternetCafe.VeriKatmani;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InternetCafe.Iskatmani.Services
{
    public class BilgisayarServices
    {
        private readonly KafedbContext _context;

        public BilgisayarServices(KafedbContext context)
        {
            _context = context;
        }

        public List<Bilgisayar> GetAll()
        {
            return _context.Bilgisayarlar.ToList();
        }

        public List<Bilgisayar> GetMusaitBilgisayarlar()
        {
            return _context.Bilgisayarlar.Where(b => b.Durum == false).ToList();
        }

        public Bilgisayar GetById(int id)
        {
            return _context.Bilgisayarlar.Find(id);
        }

        public void Add(Bilgisayar bilgisayar)
        {
            _context.Bilgisayarlar.Add(bilgisayar);
            _context.SaveChanges();
        }

        public void Update(Bilgisayar bilgisayar)
        {
            _context.Bilgisayarlar.Update(bilgisayar);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var bilgisayar = _context.Bilgisayarlar.Find(id);
            if (bilgisayar != null)
            {
                _context.Bilgisayarlar.Remove(bilgisayar);
                _context.SaveChanges();
            }
        }
    }
}
