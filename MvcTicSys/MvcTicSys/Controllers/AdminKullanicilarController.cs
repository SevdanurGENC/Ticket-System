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
    public class AdminKullanicilarController : Controller
    {
        private DBTicketSystemEntities db = new DBTicketSystemEntities();

        //
        // GET: /AdminKullanicilar/

        public ViewResult Index()
        {
            var tbl_kullanicilar = db.Tbl_Kullanicilar.Include("Tbl_Yetkiler");
            return View(tbl_kullanicilar.ToList());
        }

        //
        // GET: /AdminKullanicilar/Details/5

        public ViewResult Details(int id)
        {
            Tbl_Kullanicilar tbl_kullanicilar = db.Tbl_Kullanicilar.Single(t => t.KullaniciID == id);
            return View(tbl_kullanicilar);
        }

        //
        // GET: /AdminKullanicilar/Create

        public ActionResult Create()
        {
            ViewBag.YetkiID = new SelectList(db.Tbl_Yetkiler, "YetkiKodu", "Yetki");
            return View();
        } 

        //
        // POST: /AdminKullanicilar/Create

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
        
        //
        // GET: /AdminKullanicilar/Edit/5
 
        public ActionResult Edit(int id)
        {
            Tbl_Kullanicilar tbl_kullanicilar = db.Tbl_Kullanicilar.Single(t => t.KullaniciID == id);
            ViewBag.YetkiID = new SelectList(db.Tbl_Yetkiler, "YetkiKodu", "Yetki", tbl_kullanicilar.YetkiID);
            return View(tbl_kullanicilar);
        }

        //
        // POST: /AdminKullanicilar/Edit/5

        [HttpPost]
        public ActionResult Edit(Tbl_Kullanicilar tbl_kullanicilar)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Kullanicilar.Attach(tbl_kullanicilar);
                db.ObjectStateManager.ChangeObjectState(tbl_kullanicilar, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.YetkiID = new SelectList(db.Tbl_Yetkiler, "YetkiKodu", "Yetki", tbl_kullanicilar.YetkiID);
            return View(tbl_kullanicilar);
        }

        //
        // GET: /AdminKullanicilar/Delete/5
 
        public ActionResult Delete(int id)
        {
            Tbl_Kullanicilar tbl_kullanicilar = db.Tbl_Kullanicilar.Single(t => t.KullaniciID == id);
            return View(tbl_kullanicilar);
        }

        //
        // POST: /AdminKullanicilar/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Tbl_Kullanicilar tbl_kullanicilar = db.Tbl_Kullanicilar.Single(t => t.KullaniciID == id);
            db.Tbl_Kullanicilar.DeleteObject(tbl_kullanicilar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}