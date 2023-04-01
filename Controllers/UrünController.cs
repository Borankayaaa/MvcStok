using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrünController : Controller
    {
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index(string p)
        {
            //var urunler = db.TBLUrunler.Where(x=>x.Durum==true) ToList();
            var urunler = db.TBLUrunler.Where(x => x.Durum == true);
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(x => x.Ad.Contains(p)&&x.Durum==true);//Ürünler içerisinde ad'a göre arama yapan bir işlem ama durumu true olanlar içerisinden...
            }
            return View(urunler.ToList()); ;
        }
        [HttpGet]
        public ActionResult CreateUrün()
        {// Amaç Ürünün kategorisini listeden çekebilmek (DropdownList)
            List<SelectListItem> ktg = (from x in db.TBLKategori.ToList()
                                        select new SelectListItem
                                        {
                                            //Display(Kullanıcının gördüğü)
                                            Text = x.Ad,

                                            //Value(Arka tarafta çalışan)
                                            Value = x.Id.ToString()

                                        }).ToList();

            //Controller daki değerleri başka sayfalara taşımak için "ViewBag" kullanılır.
            ViewBag.drop = ktg;
            return View();
        }
        [HttpPost]
        public ActionResult CreateUrün(TBLUrunler t)
        {
            var ktgr = db.TBLKategori.Where(x => x.Id == t.TBLKategori.Id).FirstOrDefault();
            t.TBLKategori = ktgr;
            db.TBLUrunler.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetUrün(int id)
        {
            List<SelectListItem> kat = (from x in db.TBLKategori.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Ad,
                                            Value = x.Id.ToString()
                                        }).ToList();

            var ktgr = db.TBLUrunler.Find(id);
            ViewBag.urunkategorı = kat;
            return View("GetUrün", ktgr);
        }
        public ActionResult UpdateUrün(TBLUrunler p)
        {
            var urun = db.TBLUrunler.Find(p.Id);
            urun.Ad = p.Ad;
            urun.Marka = p.Marka;
            urun.Stok = p.Stok;
            urun.SatisFiyat = p.SatisFiyat;
            urun.AlısFiyat = p.AlısFiyat;
            var ktg = db.TBLKategori.Where(x => x.Id == p.TBLKategori.Id).FirstOrDefault();
            urun.Kategori = ktg.Id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteUrün(TBLUrunler p1)
        {
            var urunbul = db.TBLUrunler.Find(p1.Id);
            urunbul.Durum = false; //var olan ürünün durumunu false olarak düzenlicek ve passive çekecek.
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}