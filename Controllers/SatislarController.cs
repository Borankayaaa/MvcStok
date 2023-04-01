using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class SatislarController : Controller
    {

        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index()
        {
            var satislar = db.TBLSatislar.ToList();
            return View(satislar);
        }
        [HttpGet]
        public ActionResult CreateSatislar()

        //Ürünler
        {
            List<SelectListItem> urun = (from x in db.TBLUrunler.ToList()
                                         select new SelectListItem
                                         {
                                             
                                             Text = x.Ad,

                                             Value = x.Id.ToString()

                                         }).ToList();

            ViewBag.drop1 = urun;

            //Personeller

            List<SelectListItem> per = (from x in db.TBLPersonel.ToList()
                                        select new SelectListItem
                                        {
                                            
                                            Text = x.Ad +" "+ x.Soyad,

                                            Value = x.Id.ToString()

                                        }).ToList();

            ViewBag.drop2 = per;

            //Müşteriler

            List<SelectListItem> must = (from x in db.TBLMusteri.ToList()
                                        select new SelectListItem
                                        {
                                            
                                            Text = x.Ad +" "+ x.Soyad,

                                            Value = x.Id.ToString()

                                        }).ToList();

            ViewBag.drop3 = must;
            return View();

        }
        [HttpPost]
        public ActionResult CreateSatislar(TBLSatislar p)
        {

            var urun = db.TBLUrunler.Where(x => x.Id == p.TBLUrunler.Id).FirstOrDefault();
            var musteri = db.TBLMusteri.Where(x => x.Id == p.TBLMusteri.Id).FirstOrDefault();
            var personel = db.TBLPersonel.Where(x => x.Id == p.TBLPersonel.Id).FirstOrDefault();
            p.TBLUrunler = urun;
            p.TBLMusteri = musteri;
            p.TBLPersonel = personel;
            p.Tarih=DateTime.Parse(DateTime.Now.ToShortDateString()) ;
            db.TBLSatislar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}