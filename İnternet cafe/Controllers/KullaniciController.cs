using Microsoft.AspNetCore.Mvc;
using InternetCafe.Iskatmani.Services;
using InnternetCafe.Varliklar;
using InternetCafe.VeriKatmani;

namespace İnternet_cafe.Controllers
{
    public class KullaniciController : Controller
    {
        // _kullaniciService tanımla (private readonly) ✓
        private readonly KullaniciService _kullaniciService;

        // Constructor yaz - KullaniciService'i parametre al, _kullaniciService'e ata ✓
        public KullaniciController(KullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }

        // Index - tüm kullanıcıları listele, View'a gönder ✓
        public IActionResult Index()
        {
            var liste = _kullaniciService.GetAll();
            return View(liste);
        }
        // Details - int id al, GetById ile bul, View'a gönder ✓
        public IActionResult Details(int id)
        {
            var kullanici = _kullaniciService.GetById(id);
            return View(kullanici);
        }

        // Create GET - sadece return View() ✓

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Create POST - [HttpPost] ekle, Kullanici al, Add ile ekle, RedirectToAction("Index")
        [HttpPost]
        public IActionResult Create(Kullanici kullanici)
        {
            _kullaniciService.Add(kullanici);
            return RedirectToAction("Index");

        }


        // Edit GET - int id al, kullanıcıyı bul, View'a gönder
        public IActionResult Edit(int id)
        {
            var kullanici = _kullaniciService.GetById(id);
            return View(kullanici);
        }

        // Edit POST - [HttpPost] ekle, Kullanici al, Update ile güncelle, RedirectToAction("Index")
        [HttpPost]
        public IActionResult Edit(Kullanici kullanici)
        {
            _kullaniciService.Update(kullanici);
            return RedirectToAction("Index");
        }


        // Delete GET - int id al, kullanıcıyı bul, View'a gönder (onay sayfası) ✓

        public IActionResult Delete(int id)
        {
            var kullanici = _kullaniciService.GetById(id);
            return View(kullanici);
        }

        // DeleteConfirmed POST - [HttpPost, ActionName("Delete")] ekle, int id al, Delete ile sil, RedirectToAction("Index") ✓
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed (int id)
        {
             _kullaniciService.Delete(id);
             return RedirectToAction("Index");

        }
    }
}
