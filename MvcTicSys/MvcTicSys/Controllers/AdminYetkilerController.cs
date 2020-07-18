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
    public class AdminYetkilerController : Controller
    {
        private DBTicketSystemEntities db = new DBTicketSystemEntities();

        //
        // GET: /AdminYetkiler/

        public ViewResult Index()
        {
            return View(db.Tbl_Yetkiler.ToList());
        }

        //
        // GET: /AdminYetkiler/Details/5

        public ViewResult Details(int id)
        {
            Tbl_Yetkiler tbl_yetkiler = db.Tbl_Yetkiler.Single(t => t.YetkiKodu == id);
            return View(tbl_yetkiler);
        }

        //
        // GET: /AdminYetkiler/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /AdminYetkiler/Create

        [HttpPost]
        public ActionResult Create(Tbl_Yetkiler tbl_yetkiler)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Yetkiler.AddObject(tbl_yetkiler);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(tbl_yetkiler);
        }
        
        //
        // GET: /AdminYetkiler/Edit/5
 
        public ActionResult Edit(int id)
        {
            Tbl_Yetkiler tbl_yetkiler = db.Tbl_Yetkiler.Single(t => t.YetkiKodu == id);
            return View(tbl_yetkiler);
        }

        //
        // POST: /AdminYetkiler/Edit/5

        [HttpPost]
        public ActionResult Edit(Tbl_Yetkiler tbl_yetkiler)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Yetkiler.Attach(tbl_yetkiler);
                db.ObjectStateManager.ChangeObjectState(tbl_yetkiler, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_yetkiler);
        }

        //
        // GET: /AdminYetkiler/Delete/5
 
        public ActionResult Delete(int id)
        {
            Tbl_Yetkiler tbl_yetkiler = db.Tbl_Yetkiler.Single(t => t.YetkiKodu == id);
            return View(tbl_yetkiler);
        }

        //
        // POST: /AdminYetkiler/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Tbl_Yetkiler tbl_yetkiler = db.Tbl_Yetkiler.Single(t => t.YetkiKodu == id);
            db.Tbl_Yetkiler.DeleteObject(tbl_yetkiler);
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