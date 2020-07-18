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
    public class AdminOnaylarController : Controller
    {
        private DBTicketSystemEntities db = new DBTicketSystemEntities();

        //
        // GET: /AdminOnaylar/

        public ViewResult Index()
        {
            return View(db.Tbl_Onaylar.ToList());
        }

        //
        // GET: /AdminOnaylar/Details/5

        public ViewResult Details(int id)
        {
            Tbl_Onaylar tbl_onaylar = db.Tbl_Onaylar.Single(t => t.OnayID == id);
            return View(tbl_onaylar);
        }

        //
        // GET: /AdminOnaylar/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /AdminOnaylar/Create

        [HttpPost]
        public ActionResult Create(Tbl_Onaylar tbl_onaylar)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Onaylar.AddObject(tbl_onaylar);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(tbl_onaylar);
        }
        
        //
        // GET: /AdminOnaylar/Edit/5
 
        public ActionResult Edit(int id)
        {
            Tbl_Onaylar tbl_onaylar = db.Tbl_Onaylar.Single(t => t.OnayID == id);
            return View(tbl_onaylar);
        }

        //
        // POST: /AdminOnaylar/Edit/5

        [HttpPost]
        public ActionResult Edit(Tbl_Onaylar tbl_onaylar)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Onaylar.Attach(tbl_onaylar);
                db.ObjectStateManager.ChangeObjectState(tbl_onaylar, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_onaylar);
        }

        //
        // GET: /AdminOnaylar/Delete/5
 
        public ActionResult Delete(int id)
        {
            Tbl_Onaylar tbl_onaylar = db.Tbl_Onaylar.Single(t => t.OnayID == id);
            return View(tbl_onaylar);
        }

        //
        // POST: /AdminOnaylar/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Tbl_Onaylar tbl_onaylar = db.Tbl_Onaylar.Single(t => t.OnayID == id);
            db.Tbl_Onaylar.DeleteObject(tbl_onaylar);
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