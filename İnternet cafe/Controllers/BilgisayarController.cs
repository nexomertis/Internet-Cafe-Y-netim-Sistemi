using Microsoft.AspNetCore.Mvc;
using InternetCafe.Iskatmani.Services;
using InnternetCafe.Varliklar;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace İnternet_cafe.Controllers
{
    public class BilgisayarController : Controller
    {
        // _bilgisayarService tanımla (private readonly) ✓
        private readonly BilgisayarServices _bilgisayarService;

        // Constructor yaz ✓
        public BilgisayarController(BilgisayarServices bilgisayarServices)
        {
            _bilgisayarService = bilgisayarServices;
                
         }

        // Index - tüm bilgisayarları listele ✓

        public IActionResult Index()
        {
            var liste = _bilgisayarService.GetAll();
            return View(liste); 

        }

        // Details - int id al, bilgisayarı bul, View'a gönder ✓
        public IActionResult Details(int id)
        {
            var bilgisayar= _bilgisayarService.GetById(id);
            return View(bilgisayar);
        }
        [HttpGet]
        // Create GET - boş form göster ✓
        public IActionResult Create()
        {
            return View();
        }


        // Create POST - bilgisayar ekle, Index'e yönlendir ✓
        [HttpPost]
        public IActionResult Create(Bilgisayar bilgisayar)
        {
            _bilgisayarService.Add(bilgisayar);
            return RedirectToAction("Index");
        }

        // Edit GET - bilgisayarı bul, forma gönder ✓
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var bilgisayar = _bilgisayarService.GetById(id);
            return View(bilgisayar);
        }

        // Edit POST - güncelle, Index'e yönlendir ✓
        [HttpPost]
        public IActionResult Edit(Bilgisayar bilgisayar)
        {
            _bilgisayarService.Update(bilgisayar);
            return RedirectToAction("Index");
        }

        // Delete GET - bilgisayarı göster (onay sayfası) ✓
        public IActionResult Delete(int id)
        {
            var bilgisayar = _bilgisayarService.GetById(id);
            return View(bilgisayar);
        }

        // DeleteConfirmed POST - sil, Index'e yönlendir ✓
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _bilgisayarService.Delete(id);
            return RedirectToAction("Index");
            
        }

    }
}
