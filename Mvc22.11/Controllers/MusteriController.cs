using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc22._11.Models.Entity;

namespace Mvc22._11.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities db=new MvcDbStokEntities();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.TBLMUSTERI select d; //linq sorgusu degerleri tbl musterılerden cekıp  d ye atayacak
            if (!string.IsNullOrEmpty(p))
            {
                degerler=degerler.Where(m=>m.MUSTERIAD.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler= db.TBLMUSTERI.ToList();
            //return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri(string MusteriAd ,string MusteriSoyad)
        {
            TBLMUSTERI yenimusteri= new TBLMUSTERI();
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            yenimusteri.MUSTERIAD = MusteriAd;
            yenimusteri.MUSTERISOYAD = MusteriSoyad;
            db.TBLMUSTERI.Add(yenimusteri);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERI p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMUSTERI.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var musteri = db.TBLMUSTERI.Find(id);
            db.TBLMUSTERI.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBLMUSTERI.Find(id);
            return View("MusteriGetir",mus);
        }
    //    public ActionResult Guncelle(TBLMUSTERI p2)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return RedirectToAction("MusteriGetir", new { id = p2.MUSTERIID });
    //        }

    //        var mstr = db.TBLMUSTERI.Find(p2.MUSTERIID);
    //        mstr.MUSTERIAD = p2.MUSTERIAD;
    //        mstr.MUSTERISOYAD= p2.MUSTERISOYAD;

    //        db.SaveChanges();
    //        return RedirectToAction("Index");
        
    //}
        public ActionResult Guncelle(TBLMUSTERI p2)
        {
            var mstrg = db.TBLMUSTERI.Find(p2.MUSTERIID);
            mstrg.MUSTERIAD = p2.MUSTERIAD;
            mstrg.MUSTERISOYAD = p2.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
      
    }
}