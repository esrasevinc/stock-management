﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProje.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcProje.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var  degerler = db.TblKategoriler.ToList();
            var degerler = db.TblKategoriler.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(TblKategoriler t1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TblKategoriler.Add(t1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var kategori = db.TblKategoriler.Find(id);
            db.TblKategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TblKategoriler.Find(id);
            return View("KategoriGetir", ktgr);
        }

        public ActionResult Guncelle(TblKategoriler t1)
        {
            var ktgr = db.TblKategoriler.Find(t1.KategoriID);
            ktgr.KategoriAdi = t1.KategoriAdi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}