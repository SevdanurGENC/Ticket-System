using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicSys;

namespace MvcTicSys.Controllers
{ 
    public class YeniKullaniciKaydiController : Controller
    {
        private DBTicketSystemEntities db = new DBTicketSystemEntities();

        public ViewResult Index()
        {
            var tbl_kullanicilar = db.Tbl_Kullanicilar.Include("Tbl_Yetkiler");
            return View(tbl_kullanicilar.ToList());
        }
     
        public ActionResult Create()
        {
            ViewBag.YetkiID = new SelectList(db.Tbl_Yetkiler, "YetkiKodu", "Yetki");
            return View();
        } 

        [HttpPost]
        public ActionResult Create(Tbl_Kullanicilar tbl_kullanicilar)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Kullanicilar.AddObject(tbl_kullanicilar);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.YetkiID = new SelectList(db.Tbl_Yetkiler, "YetkiKodu", "Yetki", tbl_kullanicilar.YetkiID);
            return View(tbl_kullanicilar);
        }
        
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}