using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mvc22._11.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

        private ActionResult Yetki()
        {
            if (Session["Yetki"] == null)
            {
                return RedirectToAction("Giris","Giris");
            }

            return null;

        }
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult CvsSayfası()
        {
            return View();

        }
    }
}