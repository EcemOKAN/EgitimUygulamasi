using egitimUygulamasi.Areas.admin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace egitimUygulamasi.Areas.admin.Controllers
{
    public class UsersController : Controller
    {
        EgitimUygulamasiDBContext db = new EgitimUygulamasiDBContext();
        // GET: admin/Users
        public ActionResult Index()
        {
            return View(db.Kullanici.ToList());
        }
        public ActionResult Add()
        {
            ViewBag.Users = db.Konu.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Add(Kullanici kullanici)
        {

            using (EgitimUygulamasiDBContext db = new EgitimUygulamasiDBContext())
            {
                db.Kullanici.Add(kullanici);
                db.SaveChanges();
                ViewBag.Message = $"<div class='alert alert-success'><strong>Başarılı!</strong> Kullanıcı Başarıyla Eklendi... </div>";
                ViewBag.Users = db.Konu.ToList();

            }

            return View();
        }
        public ActionResult Edit(int ID)
        {
            using (EgitimUygulamasiDBContext db = new EgitimUygulamasiDBContext())
            {

                ViewBag.Users = db.Konu.ToList();
                Kullanici kullanici = db.Kullanici.SingleOrDefault(x => x.ID.Equals(ID));
                if (kullanici != null)
                {
                    return View(kullanici);
                }
            }
            return RedirectToRoute("Users");
        }

        [HttpPost]
        public ActionResult Edit(Kullanici model)
        {
            if (ModelState.IsValid)
            {
                using (EgitimUygulamasiDBContext db = new EgitimUygulamasiDBContext())
                {
                    if (db.Kullanici.SingleOrDefault(x => x.KullaniciAdi.Equals(model.KullaniciAdi) && x.ID != model.ID) == null)
                    {
                        ViewBag.Users = db.Konu.ToList();
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
                Kullanici kullanici = db.Kullanici.SingleOrDefault(x => x.ID.Equals(ID));
                if (kullanici != null)
                {
                    db.Kullanici.Remove(kullanici);
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