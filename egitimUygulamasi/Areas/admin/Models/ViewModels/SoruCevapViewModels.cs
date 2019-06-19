using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace egitimUygulamasi.Areas.admin.Models.ViewModels
{
    public class SoruCevapViewModels
    {
        public string Soru { get; set; }
        public string[] cevaplar { get; set; }
        public int Konu { get; set; }
        public string SoruTip { get; set; }
    }
}