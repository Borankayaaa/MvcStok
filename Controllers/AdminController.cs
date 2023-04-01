using MvcStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStok.Controllers
{
    public class AdminController : Controller
    {
        DbMvcStokEntities db=new DbMvcStokEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateAdmin()
        {
            return View();

        }
        [HttpPost]
        public ActionResult CreateAdmin(TBLAdmin a)
        {
            db.TBLAdmin.Add(a);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}