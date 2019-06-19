namespace egitimUygulamasi.Areas.admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanici")]
    public partial class Kullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanici()
        {
            KullaniciDers = new HashSet<KullaniciDers>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(25)]
        public string KullaniciAdi { get; set; }

        [Required]
        [StringLength(25)]
        public string Adi { get; set; }

        [Required]
        [StringLength(50)]
        public string Soyadi { get; set; }

        [Required]
        [StringLength(50)]
        public string Sifre { get; set; }

        [Required]
        [StringLength(50)]
        public string Mail { get; set; }

        [StringLength(100)]
        public string Foto { get; set; }

        public bool YoneticiMi { get; set; }

        public int KonuID { get; set; }

        public virtual Konu Konu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KullaniciDers> KullaniciDers { get; set; }
    }
}
