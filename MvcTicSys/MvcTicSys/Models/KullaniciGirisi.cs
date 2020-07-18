using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcTicSys.Models
{
    public class KullaniciGirisi
    {
        [Required]
        [Display(Name = "Kullanici Adi : ")]
        public string KullaniciAdi { get; set; }

        [Required]
        [Display(Name = "Sifre : ")]
        public string Sifre { get; set; }


    }
}