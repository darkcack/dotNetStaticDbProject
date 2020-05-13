using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBvize.Models;

namespace WEBvize.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index() // Index GET
        {
            ViewBag.CategoryList = VeriTabani.KategoriListele; // kategori Listesini ViewBag'e yüklüyoruz (dinamik navbar için )

            List<Category> categories = VeriTabani.KategoriListele;

            List<Movie> filmler = VeriTabani.FilmListele.ToList(); // Film Listeleme metodundan dönen veriyi filmler listesine atama
            return View(filmler); // filmler listesiyle view'a gitme
        }
        
        //partial view actionı . Yorum Kısımları için
        public ActionResult Com(int id) // Com GET
        {
            Movie movie = VeriTabani.FilmDetay(id); // movie nesnesine filmi id ile bulup atama
            return PartialView(movie); // movie nesnesiyle partial view'a dönme
        }

        
        public ActionResult FilmSil(int id) // FilmSil POST buton
        {
            ViewBag.CategoryList = VeriTabani.KategoriListele; // kategori Listesini ViewBag'e yüklüyoruz (dinamik navbar için )

            VeriTabani.FilmSil(id); // film idsi ile Film sil metoduna gidiyor
            return RedirectToAction("Index"); // index sayfasına geri döndürüyor

        }
        [HttpGet]
        public ActionResult FilmEkle() // FilmEkle GET
        {
            ViewBag.CategoryList = VeriTabani.KategoriListele; // kategori Listesini ViewBag'e yüklüyoruz (dinamik navbar için )
            return View(); // FilmEkle sayfasına dönüş 
        }

        [HttpPost]
        public ActionResult FilmEkle(Movie movie) // FilmEkle POST
        {
            ViewBag.CategoryList = VeriTabani.KategoriListele; // kategori Listesini ViewBag'e yüklüyoruz (dinamik navbar için )

            VeriTabani.FilmEkle(movie); // film ekle metoduna movie nesnesiyle gidiyoruz
            return RedirectToAction("index"); // index sayfasına geri döndürüyor
            
        }

        [HttpGet]
        public ActionResult FilmGuncelle(int id) // FilmGuncelle GET
        {
            Movie movie = VeriTabani.FilmDetay(id); // movie nesnesine film detaya id ile gidilip bilgilerin bulunup atanması
            ViewBag.CategoryList = VeriTabani.KategoriListele; // kategori Listesini ViewBag'e yüklüyoruz (dinamik navbar için )
            return View(movie); // movie nesnesiyle view'a gitmek
        }

        [HttpPost]
        public ActionResult FilmGuncelle(Movie movie) // FilmGuncelle POST
        {
            ViewBag.CategoryList = VeriTabani.KategoriListele; // kategori Listesini ViewBag'e yüklüyoruz (dinamik navbar için )

            VeriTabani.FilmGuncelle(movie); // Film güncelle metoduna movie nesnesiyle gidiyoruz
            return RedirectToAction("index"); // index sayfasına geri dönüyoruz

        }


        public ActionResult FilmDetay(int id) // FilmDetay GET
        {
            ViewBag.CategoryList = VeriTabani.KategoriListele; // kategori Listesini ViewBag'e yüklüyoruz (dinamik navbar için )


            Movie movie = VeriTabani.FilmDetay(id); // Filmin idsi ile geri kalan detayları getiren metotun sonucunu movie nesnesine atamakta
            return View(movie); // movie nesnesiyle filmdetaya dönüyor
        }

        [HttpPost]
        public ActionResult YorumEkle(Comment comment) // YorumEkle POST
        {
            VeriTabani.YorumEkle(comment); // comment nesnesiyle yorumekle fonksiyonuna gidiyoruz
            return RedirectToAction("FilmDetay",new {id = comment.Movieid }); //Aynı filmin detay sayfasına geri dönüyoruz
        }

        public ActionResult YorumSil(int id)
        {
            int filmid = 0;
            ViewBag.CategoryList = VeriTabani.KategoriListele; // kategori Listesini ViewBag'e yüklüyoruz (dinamik navbar için )
            filmid = VeriTabani.YorumlaBul(id); // aynı filmin detay sayfasına dönebilmek için filmin idsini buluyoruz
            VeriTabani.YorumSil(id); // id ile yorumsil fonksiyonuna gidiyoruz ve yorumu siliyoruz
            return RedirectToAction("FilmDetay", new { id = filmid}); // aynı filmin detay sayfasına geri dönüyoruz

        }


    }
}