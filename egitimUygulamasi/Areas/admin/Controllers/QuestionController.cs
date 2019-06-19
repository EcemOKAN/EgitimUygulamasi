 using egitimUygulamasi.Areas.admin.Models;
using egitimUygulamasi.Areas.admin.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace egitimUygulamasi.Areas.admin.Controllers
{
    public class QuestionController : Controller
    {
        EgitimUygulamasiDBContext db = new EgitimUygulamasiDBContext();

        // GET: admin/Question
        public ActionResult Index()
        {
            ViewBag.Question = db.Konu.ToList();
            return View(db.Soru.ToList());

        }
        public ActionResult Add()
        {
            ViewBag.Question = db.Konu.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Add(SoruCevapViewModels model)
        {

            Soru _soru = new Soru();
            _soru.Sorular = model.Soru;
            _soru.SoruTipID = db.SoruTip.SingleOrDefault(x => x.SoruTipAdi.Equals(model.SoruTip)).ID;
            _soru.KonuID = model.Konu;
            _soru.QuizMi = true;

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

            ViewBag.Question = db.Konu.ToList();


            db.SaveChanges();


            return View();
        }

        public ActionResult Edit(int ID)
        {
            using (EgitimUygulamasiDBContext db = new EgitimUygulamasiDBContext())
            {

                ViewBag.Question = db.Konu.ToList();
                Soru soru = db.Soru.SingleOrDefault(x => x.ID.Equals(ID));
                if (soru != null)
                {
                    return View(soru);
                }
            }
            return RedirectToRoute("Questions");
        }

        [HttpPost]
        public ActionResult Edit(Soru model)
        {
            if (ModelState.IsValid)
            {
                using (EgitimUygulamasiDBContext db = new EgitimUygulamasiDBContext())
                {
                    if (db.Soru.SingleOrDefault(x => x.Sorular.Equals(model.Sorular) && x.ID != model.ID) == null)
                    {
                        ViewBag.Question = db.Konu.ToList();
                        db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        ViewBag.Message = $"<div class='alert alert-success'><strong>Başarılı!</strong> Test Başarıyla Güncellendi... </div>";
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


        public ActionResult Delete()
        {
            return View();
        }

    }
}