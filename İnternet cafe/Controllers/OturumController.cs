using Microsoft.AspNetCore.Mvc;
using InternetCafe.Iskatmani.Services;
using InnternetCafe.Varliklar;

namespace İnternet_cafe.Controllers
{
    public class OturumController : Controller
    {
        // _oturumService tanımla (private readonly)
        private readonly OturumService _oturumservice;

        // TODO: _kullaniciService tanımla (private readonly) - dropdown için lazım
        private readonly KullaniciService _kullaniciservice;

        // TODO: _bilgisayarService tanımla (private readonly) - dropdown için lazım
        private readonly BilgisayarServices _bilgisayarservice;
        // Constructor yaz
        // TODO: Constructor'a KullaniciService ve BilgisayarServices parametrelerini ekle
        public OturumController(OturumService oturumService , KullaniciService kullaniciService , BilgisayarServices bilgisayarServices)
        {
           _oturumservice = oturumService;
            _kullaniciservice = kullaniciService;
            _bilgisayarservice = bilgisayarServices;
           // TODO: _kullaniciService = ...
           // TODO: _bilgisayarService = ...
        }

        // Index - tüm oturumları listele
        public IActionResult Index()
        {
            var liste = _oturumservice.GetAll();
            return View(liste);
        }

        // Details - int id al, oturumu bul, View'a gönder
        public IActionResult Details(int id)
        {
           var oturum = _oturumservice.GetById(id);
            return View(oturum);
        }

        // Create GET - boş form göster
        [HttpGet]
        public IActionResult Create()
        {
           return View();
         }

        // Create POST - oturum ekle, Index'e yönlendir
        [HttpPost]
        public IActionResult Create(Oturum oturum)
        {
            _oturumservice.Add(oturum);
            return RedirectToAction("Index");

        }

        // Edit GET - oturumu bul, forma gönder
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var oturum = _oturumservice.GetById(id);
            return View(oturum);
        }

        // Edit POST - güncelle, Index'e yönlendir
        [HttpPost]
        public IActionResult Edit(Oturum oturum)
        {
            _oturumservice.Update(oturum);
            return RedirectToAction("Index"); 

        }

        // Delete GET - oturumu göster (onay sayfası)
        [HttpGet]
        public IActionResult Delete(int id)
        {
          var oturum = _oturumservice.GetById(id);
            return View(oturum);
        }

        // DeleteConfirmed POST - sil, Index'e yönlendir
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _oturumservice.Delete(id);
            return RedirectToAction("Index");
            
        }

        // ========== ÖZEL METODLAR ==========

        // OturumBaslat GET - form göster (kullaniciId ve bilgisayarId seçimi için)
        [HttpGet]
        public IActionResult OturumBaslat()
        {
            // TODO: _kullaniciService.GetAll() ile kullanıcıları al, ViewBag.Kullanicilar'a ata
            ViewBag.Kullanicilar = _kullaniciservice.GetAll();
            // TODO: _bilgisayarService.GetAll() ile bilgisayarları al, ViewBag.Bilgisayarlar'a ata
            ViewBag.Bilgisayarlar = _bilgisayarservice.GetMusaitBilgisayarlar();
            return View();
        }

        // OturumBaslat POST - _oturumService.OturumBaslat(kullaniciId, bilgisayarId) çağır, Index'e yönlendir
        [HttpPost]
        public IActionResult OturumBaslat(int kullaniciId, int bilgisayarId)

        {
            _oturumservice.OturumBaslat(kullaniciId, bilgisayarId);
            return RedirectToAction("Index");
        }

        // OturumBitir GET - int id al, oturumu göster
        [HttpGet]
        public IActionResult OturumBitir(int id)
        {
            var oturum = _oturumservice.GetById(id);
            return View(oturum);
        }

        // OturumBitir POST - _oturumService.OturumBitir(id) çağır, Index'e yönlendir
        [HttpPost,ActionName("OturumBitir")]
        public IActionResult OturumBitirConfirmed(int id)
        {
           var oturum = _oturumservice.OturumBitir(id);
            return RedirectToAction("Index");
        }
       
    }
}
