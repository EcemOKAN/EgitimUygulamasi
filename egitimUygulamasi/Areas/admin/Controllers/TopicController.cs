using egitimUygulamasi.Areas.admin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace egitimUygulamasi.Areas.admin.Controllers
{
    public class TopicController : Controller
    {
        // GET: admin/Topic
        EgitimUygulamasiDBContext db = new EgitimUygulamasiDBContext();
        public ActionResult Index()
        {
            return View(db.Konu.ToList());
        }

        public ActionResult Add()
        {
            ViewBag.Topics = db.Ders.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Add(Konu konu)
        {

            using (EgitimUygulamasiDBContext db = new EgitimUygulamasiDBContext())
            {
                db.Konu.Add(konu);
                db.SaveChanges();
                ViewBag.Message = $"<div class='alert alert-success'><strong>Başarılı!</strong> Ders Başarıyla Eklendi... </div>";
                ViewBag.Topics = db.Ders.ToList();

            }

            return View();
        }
        
        public ActionResult Edit(int ID)
        {
            using (EgitimUygulamasiDBContext db = new EgitimUygulamasiDBContext())
            {

                ViewBag.Topics = db.Ders.ToList();
                Konu konu = db.Konu.SingleOrDefault(x => x.ID.Equals(ID));
                if (konu != null)
                {
                    return View(konu);
                }
            }
            return RedirectToRoute("Topics");
        }

        [HttpPost]
        public ActionResult Edit(Konu model)
        {
            if (ModelState.IsValid)
            {
                using (EgitimUygulamasiDBContext db = new EgitimUygulamasiDBContext())
                {
                    if (db.Konu.SingleOrDefault(x => x.KonuAdi.Equals(model.KonuAdi) && x.ID != model.ID) == null)
                    {
                        ViewBag.Topics = db.Ders.ToList();
                        db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        ViewBag.Message = $"<div class='alert alert-success'><strong>Başarılı!</strong> Konu Başarıyla Güncellendi... </div>";
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.Message = $"<div class='alert alert-danger'><strong>Hata!</strong> Bu konu adı zaten kullanılıyor... </div>";
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public string Delete(int ID)
        {
            string message = string.Empty;
            using (EgitimUygulamasiDBContext db = new EgitimUygulamasiDBContext())
            {
                Konu konu = db.Konu.SingleOrDefault(x => x.ID.Equals(ID));
                if (konu != null)
                {
                    db.Konu.Remove(konu);
                    db.SaveChanges();
                    message = JsonConvert.SerializeObject(new { durum = "OK", mesaj = "Konu Silindi" });
                }
                else
                {
                    message = JsonConvert.SerializeObject(new { durum = "No", mesaj = "Konu Silinemedi" });
                }
            }
            return message;
        }
    }
}