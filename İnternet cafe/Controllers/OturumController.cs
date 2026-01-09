using Microsoft.AspNetCore.Mvc;
using InternetCafe.Iskatmani.Services;
using InnternetCafe.Varliklar;

namespace İnternet_cafe.Controllers
{
    public class OturumController : Controller
    {
        private readonly OturumService _oturumservice;
        private readonly KullaniciService _kullaniciservice;
        private readonly BilgisayarServices _bilgisayarservice;

        public OturumController(OturumService oturumService, KullaniciService kullaniciService, BilgisayarServices bilgisayarServices)
        {
            _oturumservice = oturumService;
            _kullaniciservice = kullaniciService;
            _bilgisayarservice = bilgisayarServices;
        }

        public IActionResult Index()
        {
            var liste = _oturumservice.GetAll();
            return View(liste);
        }

        public IActionResult Details(int id)
        {
            var oturum = _oturumservice.GetById(id);
            return View(oturum);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Oturum oturum)
        {
            _oturumservice.Add(oturum);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var oturum = _oturumservice.GetById(id);
            return View(oturum);
        }

        [HttpPost]
        public IActionResult Edit(Oturum oturum)
        {
            _oturumservice.Update(oturum);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var oturum = _oturumservice.GetById(id);
            return View(oturum);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _oturumservice.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult OturumBaslat()
        {
            ViewBag.Kullanicilar = _kullaniciservice.GetAll();
            ViewBag.Bilgisayarlar = _bilgisayarservice.GetMusaitBilgisayarlar();
            return View();
        }

        [HttpPost]
        public IActionResult OturumBaslat(int kullaniciId, int bilgisayarId)
        {
            _oturumservice.OturumBaslat(kullaniciId, bilgisayarId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult OturumBitir(int id)
        {
            var oturum = _oturumservice.GetById(id);
            return View(oturum);
        }

        [HttpPost, ActionName("OturumBitir")]
        public IActionResult OturumBitirConfirmed(int id)
        {
            var oturum = _oturumservice.OturumBitir(id);
            return RedirectToAction("Index");
        }
    }
}
