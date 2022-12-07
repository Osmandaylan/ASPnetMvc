using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc22._11.Controllers
{
    public class GirisController : Controller
    {
        public string publickullanıcıAdi = "osman";
        public string publicSifre = "sifre";
        // GET: Giris
        public ActionResult Index()
        {
            var x = 5;
            return View();
        }
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(FormCollection fc) 
        {
            string kullaniciAdi = fc["kullaniciAdi"];
            string sifre = fc["sifre"];
            if (kullaniciAdi==publickullanıcıAdi && sifre==publicSifre)
            {
                Session["Yetki"] = kullaniciAdi;
                return Redirect("/Home/Index");
            }
            else { return View(); }
            
        }
    }
}