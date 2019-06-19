using egitimUygulamasi.Areas.admin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace egitimUygulamasi.Areas.admin.Controllers
{
    public class LessonController : Controller
    {
        // GET: admin/Lesson
        public ActionResult Index()
        {
            using (EgitimUygulamasiDBContext db = new EgitimUygulamasiDBContext())
            {
                return View(db.Ders.ToList()); // select * from dersler
            }
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Ders model)
        {
            if (ModelState.IsValid)
            {
                using (EgitimUygulamasiDBContext db = new EgitimUygulamasiDBContext())
                {
                    if (db.Ders.SingleOrDefault(x => x.DersAdi.Equals(model.DersAdi)) == null)
                    {
                        db.Entry(model).State = System.Data.Entity.EntityState.Added;
                        db.SaveChanges();
                        ViewBag.Message = $"<div class='alert alert-success'><strong>Başarılı!</strong> Ders Başarıyla Eklendi... </div>";
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.Message = $"<div class='alert alert-danger'><strong>Hata!</strong> Bu ders adı zaten kullanılıyor... </div>";
                    }
                }
            }
            return View(model);
        }
        public ActionResult Edit(int ID)
        {
            using (EgitimUygulamasiDBContext db = new EgitimUygulamasiDBContext())
            {
                Ders ders = db.Ders.SingleOrDefault(x => x.ID.Equals(ID));
                if (ders != null)
                {
                    return View(ders);
                }
            }
            return RedirectToRoute("Lessons");
        }

        [HttpPost]
        public ActionResult Edit(Ders model , HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                using (EgitimUygulamasiDBContext db = new EgitimUygulamasiDBContext())
                {
                    if (db.Ders.SingleOrDefault(x => x.DersAdi.Equals(model.DersAdi) && x.ID != model.ID) == null)
                    {
                        db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        ViewBag.Message = $"<div class='alert alert-success'><strong>Başarılı!</strong> Ders Başarıyla Güncellendi... </div>";
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.Message = $"<div class='alert alert-danger'><strong>Hata!</strong> Bu ders adı zaten kullanılıyor... </div>";
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
                Ders ders = db.Ders.SingleOrDefault(x => x.ID.Equals(ID));
                if (ders != null)
                {
                    db.Ders.Remove(ders);
                    db.SaveChanges();
                    message = JsonConvert.SerializeObject(new { durum = "OK", mesaj = "Ders Silindi" });
                }
                else
                {
                    message = JsonConvert.SerializeObject(new { durum = "No", mesaj = "Ders Silinemedi" });
                }
            }
            return message;
        }
    }
}