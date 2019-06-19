using egitimUygulamasi.Areas.admin.Models;
using egitimUygulamasi.Areas.admin.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace egitimUygulamasi.Areas.admin.Controllers
{
    public class TopiccontentController : Controller
    {
        EgitimUygulamasiDBContext db = new EgitimUygulamasiDBContext();
        // GET: admin/Topiccontent
        public ActionResult Index()
        {
            return View(db.KonuIcerik.ToList());
        }
        public ActionResult Add()
        {
            ViewBag.TopicContent = db.Konu.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Add(KonuIcerikViewModel model)
        {
            Soru _soru = new Soru();
            _soru.Sorular = model.Soru;
            _soru.SoruTipID = db.SoruTip.SingleOrDefault(x => x.SoruTipAdi.Equals(model.SoruTip)).ID;
            _soru.KonuID = model.Konu;
            _soru.QuizMi = false;

            db.Soru.Add(_soru);
            List<Cevap> _cevaplar = new List<Cevap>();
            for (int i = 0; i < model.cevaplar.Length; i++)
            {
                Cevap _cevap = new Cevap();
                _cevap.DogruMu = (i == 0) ? true : false;
                _cevap.Cevaplar = model.cevaplar[i];
                _cevap.SoruID = _soru.ID;
                _cevaplar.Add(_cevap);
            }

            db.Cevap.AddRange(_cevaplar);


            KonuIcerik _konuIcerik = new KonuIcerik();
            _konuIcerik.KonuID = model.Konu;
            _konuIcerik.SoruID = _soru.ID;
            _konuIcerik.Icerik = model.Icerik;

            db.KonuIcerik.Add(_konuIcerik);

            db.SaveChanges();
            
          
            ViewBag.TopicContent = db.Konu.ToList();
            return View();
        }
        public ActionResult Edit(int ID)
        {
            using (EgitimUygulamasiDBContext db = new EgitimUygulamasiDBContext())
            {

                ViewBag.TopicContent = db.Konu.ToList();
                KonuIcerik konu = db.KonuIcerik.SingleOrDefault(x => x.ID.Equals(ID));
                if (konu != null)
                {
                    return View(konu);
                }
            }
            return RedirectToRoute("Topics");
        }

        [HttpPost]
        public ActionResult Edit(KonuIcerik model)
        {
            if (ModelState.IsValid)
            {
                using (EgitimUygulamasiDBContext db = new EgitimUygulamasiDBContext())
                {
                    if (db.KonuIcerik.SingleOrDefault(x => x.Icerik.Equals(model.Icerik) && x.ID != model.ID) == null)
                    {
                        ViewBag.TopicContent = db.Konu.ToList();
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
                KonuIcerik konu = db.KonuIcerik.SingleOrDefault(x => x.ID.Equals(ID));
                if (konu != null)
                {
                    db.KonuIcerik.Remove(konu);
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