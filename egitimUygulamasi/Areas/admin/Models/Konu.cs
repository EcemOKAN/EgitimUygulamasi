namespace egitimUygulamasi.Areas.admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Konu")]
    public partial class Konu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Konu()
        {
            KonuIcerik = new HashSet<KonuIcerik>();
            Kullanici = new HashSet<Kullanici>();
            Soru = new HashSet<Soru>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string KonuAdi { get; set; }

        [StringLength(100)]
        public string Resim { get; set; }

        public int DersID { get; set; }

        public virtual Ders Ders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KonuIcerik> KonuIcerik { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kullanici> Kullanici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Soru> Soru { get; set; }
    }
}
