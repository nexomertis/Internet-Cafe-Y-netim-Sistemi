using Microsoft.EntityFrameworkCore;
using InnternetCafe.Varliklar;
using InternetCafe.VeriKatmani;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetCafe.Iskatmani.Services
{
    public class OturumService
    {
        private readonly KafedbContext _context;
        public OturumService(KafedbContext context)
        {
            _context = context;
        }
        public List<Oturum> GetAll()
        {

             
            // TODO: Include ile ilişkili verileri çek 
           return _context.Oturumlar.Include(o => o.Kullanici).Include(o => o.Bilgisayar).ToList();
 
        }
        public Oturum GetById(int id)
        {
            return _context.Oturumlar
                .Include(o => o.Kullanici)
                .Include(o => o.Bilgisayar)
                .FirstOrDefault(o => o.Id == id);
        }
        public void Add(Oturum oturumlar)
        {
            _context.Oturumlar.Add(oturumlar);
            _context.SaveChanges();
        }
        public void Update(Oturum oturumlar)
        {
            _context.Oturumlar.Update(oturumlar);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var oturum = _context.Oturumlar.Find(id);
            if (oturum != null)
            {
                _context.Oturumlar.Remove(oturum);
                _context.SaveChanges();
            }


        }
        public Oturum OturumBaslat(int kullaniciId, int bilgisayarId)
        {
            // TODO: Bilgisayarı bul (OturumBitir metodundaki gibi)
            var bilgisayar = _context.Bilgisayarlar.Find(bilgisayarId);
            // TODO: Eğer bilgisayar doluysa return null
            if (bilgisayar == null) return null;
            if (bilgisayar.Durum == true) return null;
                        
            // TODO: Bilgisayarı dolu yap
            bilgisayar.Durum = true;
            
            
            //yeni oturum oluştur 
            var oturum = new Oturum()
            {
                KullaniciId = kullaniciId,
                BilgisayarId = bilgisayarId,
                BaslangicZamanı = DateTime.Now,
            };
            _context.Oturumlar.Add(oturum);
            _context.SaveChanges();

            return oturum;
        }
        // Müşteri kalktı,ÜcretHesapla
        public Oturum OturumBitir(int oturumId)
        {
            var oturum = _context.Oturumlar.Find(oturumId);
            if (oturum == null) return null;

            oturum.BitisZamani = DateTime.Now;

            // Süreyi Hesapla (saat olarak)
            var sure = (oturum.BitisZamani.Value - oturum.BaslangicZamanı).TotalHours;

            //bilgisayarı sattlik ücretini al 
            var bilgisayar = _context.Bilgisayarlar.Find(oturum.BilgisayarId);
            if (bilgisayar == null) return null;
            oturum.ToplamUcret = (decimal)sure * bilgisayar.SaatlikUcret;

            // TODO: bilgisayar.Durum = false yap (artık boş)
            //Bilgisayar Durumu
            bilgisayar.Durum = false;
           
            _context.SaveChanges();
            
            return oturum;


        }
    }
}
