using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Mvc22._11.Models.Entity;

namespace Mvc22._11.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStokEntities db=new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler=db.TBLURUNLER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniUrun() 
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text=i.KATEGORIAD,
                                                 Value=i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler; //linq sorgusu yapılıyor dropdown list için

            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(TBLURUNLER p2)
        {
            var ktg=db.TBLKATEGORILER.Where(m=>m.KATEGORIID==p2.TBLKATEGORILER.KATEGORIID).FirstOrDefault(); //burasıda lıng sorgusu secmiş oldugumuz degeri getirecek
            p2.TBLKATEGORILER = ktg;
            db.TBLURUNLER.Add(p2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            //ürün silmeyle ilgili kodlar.
            var urun = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urn = db.TBLURUNLER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir",urn);

        }
        public ActionResult Guncelle(TBLURUNLER p)
        {
            var urun = db.TBLURUNLER.Find(p.URUNID);
            urun.URUNAD = p.URUNAD;
            urun.MARKA= p.MARKA;
            urun.STOK= p.STOK;
            urun.FIYAT= p.FIYAT;
            //urun.URUNKATEGORI= p.URUNKATEGORI;
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p.TBLKATEGORILER.KATEGORIID).FirstOrDefault(); //burasıda lıng sorgusu secmiş oldugumuz degeri getirecek
            urun.URUNKATEGORI = ktg.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}