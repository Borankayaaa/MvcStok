using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        DbMvcStokEntities db= new DbMvcStokEntities();
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            //var musteriliste=db.TBLMusteri.ToList();
            var musteriliste = db.TBLMusteri.Where(x=>x.Durum==true).ToList().ToPagedList(sayfa, 3);
            return View(musteriliste);
        }
        [HttpGet]
        public ActionResult CreateMusteri()
        {
            return View();

        }
        [HttpPost]
        public ActionResult CreateMusteri(TBLMusteri p)
        {
            if(!ModelState.IsValid)
            {
                return View("CreateMusteri");
            }
            p.Durum = true; // Verinin eklendiğinde durumunu null'dan kurtarıp true yapar ve tabloda gösterilmesini sağlar.
            db.TBLMusteri.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DeleteMusteri(TBLMusteri p)
        {
            var musteribul = db.TBLMusteri.Find(p.Id);
            musteribul.Durum = false; //var olan ürünün durumunu false olarak düzenlicek ve passive çekecek.
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetMusteri(int id)
        {
            var mus = db.TBLMusteri.Find(id);           
            return View("GetMusteri", mus);
        }
        public ActionResult UpdateMusteri(TBLMusteri t)
        {
            var mus = db.TBLMusteri.Find(t.Id);
            mus.Ad=t.Ad;
            mus.Soyad=t.Soyad;
            mus.Sehir=t.Sehir;
            mus.Bakıye = t.Bakıye;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}