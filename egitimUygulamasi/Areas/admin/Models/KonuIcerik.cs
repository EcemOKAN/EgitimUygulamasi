namespace egitimUygulamasi.Areas.admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KonuIcerik")]
    public partial class KonuIcerik
    {
        public int ID { get; set; }

        [Required]
        public string Icerik { get; set; }

        public int KonuID { get; set; }

        public int SoruID { get; set; }

        public virtual Konu Konu { get; set; }

        public virtual Soru Soru { get; set; }
    }
}
