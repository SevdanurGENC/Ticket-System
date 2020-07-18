using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcTicSys.Controllers
{
    public class KullaniciGirisiController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Giris()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Giris(Models.KullaniciGirisi user)
        {
            if (ModelState.IsValid)
            {
                if (IsValid(user.KullaniciAdi, user.Sifre))
                {
                    if (user.KullaniciAdi == "Admin")
                    {
                        FormsAuthentication.SetAuthCookie(user.KullaniciAdi, false);
                        return RedirectToAction("Index", "AdminEkrani");
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(user.KullaniciAdi, false);
                        return RedirectToAction("Index", "UserEkrani");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Girisiniz Hatalidir.");
                }
            }

            return View(user);
        }
         

        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "KullaniciGirisi");
        }

         
        private bool IsValid(string kullaniciadi, string sifre)
        {
            bool isValid = false;

            using (var db = new DBTicketSystemEntities())
            {
                var user = db.Tbl_Kullanicilar.FirstOrDefault(u => u.KullaniciAdi == kullaniciadi);
                if (user != null)
                {
                    if (user.Sifre == sifre)
                    {
                        isValid = true;
                    }
                }

            }

            return isValid;
        }




    }
}
