using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index()
        {
            var kategoriler = db.TBLKategori.ToList(); // var değişkeninin sebebi kategorilerin içerisine yazı,sayı,karakter gibi bir çok şey gelebileceğinden tanımlanmıştır.
            return View(kategoriler);
            
        }
        [HttpGet]
        public ActionResult CreateKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateKategori(TBLKategori p)
        {
            db.TBLKategori.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteKategori(int id)
        {
           var ktg= db.TBLKategori.Find(id);
            db.TBLKategori.Remove(ktg);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult GetKategori(int id)
        {
            var ktgr = db.TBLKategori.Find(id);      
            return View("GetKategori",ktgr);
        }
        public ActionResult UpdateKategori(TBLKategori k)
        {
            var ktg = db.TBLKategori.Find(k.Id);
            ktg.Ad = k.Ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}