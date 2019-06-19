namespace egitimUygulamasi.Areas.admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Soru")]
    public partial class Soru
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Soru()
        {
            Cevap = new HashSet<Cevap>();
            KonuIcerik = new HashSet<KonuIcerik>();
        }

        public int ID { get; set; }

        [Required]
        public string Sorular { get; set; }

        public bool QuizMi { get; set; }

        public int SoruTipID { get; set; }

        public int KonuID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cevap> Cevap { get; set; }

        public virtual Konu Konu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KonuIcerik> KonuIcerik { get; set; }

        public virtual SoruTip SoruTip { get; set; }
    }
}
