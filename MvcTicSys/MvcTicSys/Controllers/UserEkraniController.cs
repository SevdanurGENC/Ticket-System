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
    public class UserEkraniController : Controller
    {
        private DBTicketSystemEntities db = new DBTicketSystemEntities();
 
        public ViewResult Index()
        {
            var tbl_sikayetler = db.Tbl_Sikayetler.Include("Tbl_Kullanicilar").Include("Tbl_Onaylar");
            return View(tbl_sikayetler.ToList());
        }

        public ViewResult Details(int id)
        {
            Tbl_Sikayetler tbl_sikayetler = db.Tbl_Sikayetler.Single(t => t.SikayetID == id);
            return View(tbl_sikayetler);
        }

        public ActionResult Create()
        {
            ViewBag.KullaniciID = new SelectList(db.Tbl_Kullanicilar, "KullaniciID", "KullaniciAdi");
            ViewBag.Onay = new SelectList(db.Tbl_Onaylar, "OnayID", "Onay");
            return View();
        } 

        [HttpPost]
        public ActionResult Create(Tbl_Sikayetler tbl_sikayetler)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Sikayetler.AddObject(tbl_sikayetler);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.KullaniciID = new SelectList(db.Tbl_Kullanicilar, "KullaniciID", "KullaniciAdi", tbl_sikayetler.KullaniciID);
            ViewBag.Onay = new SelectList(db.Tbl_Onaylar, "OnayID", "Onay", tbl_sikayetler.Onay);
            return View(tbl_sikayetler);
        } 
 
        public ActionResult Edit(int id)
        {
            Tbl_Sikayetler tbl_sikayetler = db.Tbl_Sikayetler.Single(t => t.SikayetID == id);
            ViewBag.KullaniciID = new SelectList(db.Tbl_Kullanicilar, "KullaniciID", "KullaniciAdi", tbl_sikayetler.KullaniciID);
            ViewBag.Onay = new SelectList(db.Tbl_Onaylar, "OnayID", "Onay", tbl_sikayetler.Onay);
            return View(tbl_sikayetler);
        } 

        [HttpPost]
        public ActionResult Edit(Tbl_Sikayetler tbl_sikayetler)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Sikayetler.Attach(tbl_sikayetler);
                db.ObjectStateManager.ChangeObjectState(tbl_sikayetler, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KullaniciID = new SelectList(db.Tbl_Kullanicilar, "KullaniciID", "KullaniciAdi", tbl_sikayetler.KullaniciID);
            ViewBag.Onay = new SelectList(db.Tbl_Onaylar, "OnayID", "Onay", tbl_sikayetler.Onay);
            return View(tbl_sikayetler);
        }
 
        public ActionResult Delete(int id)
        {
            Tbl_Sikayetler tbl_sikayetler = db.Tbl_Sikayetler.Single(t => t.SikayetID == id);
            return View(tbl_sikayetler);
        }
         
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Tbl_Sikayetler tbl_sikayetler = db.Tbl_Sikayetler.Single(t => t.SikayetID == id);
            db.Tbl_Sikayetler.DeleteObject(tbl_sikayetler);
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