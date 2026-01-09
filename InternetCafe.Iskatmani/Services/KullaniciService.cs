using InnternetCafe.Varliklar;
using InternetCafe.VeriKatmani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetCafe.Iskatmani.Services
{
    public class KullaniciService
    {
        //cotext = veritabanını bağlantımız
        //readonly = sadece constructor da değer atanabilir sonra değiştirelemez
        //private = sadece bu class içinden erişilebilir
        private readonly KafedbContext _context;

        // constructor = class oluşturulunca ilk çalışan metod
        // dışarıdan kafedbContext alıyoruz (dependency Injection)
        //kendimiz oluşturmuyoruz bize veriliyor
        public KullaniciService(KafedbContext context)
        {
            _context = context; //gelen context saklıyoruz
        }

        //Tüm kullanıcıları getir 
        public List<Kullanici> GetAll()
        {
            return _context.Kullanicilar.ToList();
        }

        // Id ye göre tek kullanıcı getir
        public Kullanici GetById(int id)
        {
            return _context.Kullanicilar.Find(id);
        }

        //yeni kullanıcı ekle
        public void Add(Kullanici kullanici)
        {
            _context.Kullanicilar.Add(kullanici); // hafızaya ekle
            _context.SaveChanges(); // Veri tabanına kaydet
        }

        // Kullanıcı güncelle
        public void Update(Kullanici kullanici)
        {
            _context.Kullanicilar.Update(kullanici);
            _context.SaveChanges();
        }
        
        //kullanıcı sil 
        public void Delete(int id)
        {
            var kullanici = _context.Kullanicilar.Find(id); // önce bul 
            if (kullanici != null)
            {
                _context.Kullanicilar.Remove(kullanici); //hafızadan sil
                _context.SaveChanges();                  //veritabanından sil 
            }
        }
        
    }
}
