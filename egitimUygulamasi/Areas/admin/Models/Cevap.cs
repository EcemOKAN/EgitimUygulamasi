namespace egitimUygulamasi.Areas.admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cevap")]
    public partial class Cevap
    {
        public int ID { get; set; }

        [Column("Cevap")]
        [Required]
        public string Cevaplar { get; set; }

        public bool DogruMu { get; set; }

        public int SoruID { get; set; }

        public virtual Soru Soru { get; set; }
    }
}
