using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using System.Web.Security;

namespace MvcStok.Controllers
{

    public class GirisYapController : Controller
    {
        DbMvcStokEntities db = new DbMvcStokEntities();

        [HttpGet]
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(TBLAdmin t)
        {
            var bilgiler = db.TBLAdmin.FirstOrDefault(x => x.Kullanici == t.Kullanici && x.Sifre == t.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Kullanici, false);
                return RedirectToAction("Index", "Musteri");
            }
            else
            {
                return View();
            }

        }
    }
}