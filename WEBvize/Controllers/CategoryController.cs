using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBvize.Models;

namespace WEBvize.Controllers
{
    public class CategoryController: Controller
    {
        public ActionResult KategoriIndex() // Tüm kategoriler sayfası GET
        {
            ViewBag.CategoryList = VeriTabani.KategoriListele; // kategori Listesini ViewBag'e yüklüyoruz (dinamik navbar için )

            List<Category> kategoriler = VeriTabani.KategoriListele;  // kategoriler listesi oluşturuyoruz . returnde bu liste dönecek
            return View(kategoriler);
        }

        [HttpPost]
        public ActionResult KategoriEkle(Category category) // Tüm Kategoriler sayfası POST
        {
            ViewBag.CategoryList = VeriTabani.KategoriListele; // kategori Listesini ViewBag'e yüklüyoruz (dinamik navbar için )

            VeriTabani.KategoriEkle(category);  // category nesnesini KategoriEkle fonksiyonuna gönderiyoruz
            return RedirectToAction("KategoriIndex"); // KategoriIndex Sayfasına geri dönüyoruz

        }

        [HttpGet]
        public ActionResult KategoriEkle() // Kategori Ekle sayfası GET
        {
            ViewBag.CategoryList = VeriTabani.KategoriListele; // kategori Listesini ViewBag'e yüklüyoruz (dinamik navbar için )
            return View(); // KategoriEkle view'ına dönüyoruz
        }

        public ActionResult KategoriDetay(int id)
        {
            ViewBag.CategoryList = VeriTabani.KategoriListele; // kategori Listesini ViewBag'e yüklüyoruz (dinamik navbar için )
            ViewBag.katid = VeriTabani.KategoriBul(id); // Dinamik başlık için kategori idsi ile kategori bulmaktayız
            List<Movie> m = VeriTabani.KategoriDetay(id); // Film Listesi döndürüyoruz çünkü view'a bu gönderilecek
            return View(m);
        }

        public ActionResult KategoriSil(int id)
        {
            ViewBag.CategoryList = VeriTabani.KategoriListele; // kategori Listesini ViewBag'e yüklüyoruz (dinamik navbar için )

            VeriTabani.KategoriSil(id); // Kategori Sil fonksiyonuna gidiyor
            return RedirectToAction("KategoriIndex"); // Sildikten Sonra Kategoriİndex'e geri döndürüyor

        }
    }
}