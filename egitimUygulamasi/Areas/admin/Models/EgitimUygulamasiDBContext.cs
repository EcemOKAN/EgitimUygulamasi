namespace egitimUygulamasi.Areas.admin.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EgitimUygulamasiDBContext : DbContext
    {
        public EgitimUygulamasiDBContext()
            : base("name=EgitimUygulamasiDBContext")
        {
        }

        public virtual DbSet<Cevap> Cevap { get; set; }
        public virtual DbSet<Ders> Ders { get; set; }
        public virtual DbSet<Konu> Konu { get; set; }
        public virtual DbSet<KonuIcerik> KonuIcerik { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<KullaniciDers> KullaniciDers { get; set; }
        public virtual DbSet<Soru> Soru { get; set; }
        public virtual DbSet<SoruTip> SoruTip { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ders>()
                .HasMany(e => e.Konu)
                .WithRequired(e => e.Ders)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ders>()
                .HasMany(e => e.KullaniciDers)
                .WithRequired(e => e.Ders)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Konu>()
                .HasMany(e => e.KonuIcerik)
                .WithRequired(e => e.Konu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Konu>()
                .HasMany(e => e.Kullanici)
                .WithRequired(e => e.Konu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Konu>()
                .HasMany(e => e.Soru)
                .WithRequired(e => e.Konu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.KullaniciDers)
                .WithRequired(e => e.Kullanici)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Soru>()
                .HasMany(e => e.Cevap)
                .WithRequired(e => e.Soru)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Soru>()
                .HasMany(e => e.KonuIcerik)
                .WithRequired(e => e.Soru)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SoruTip>()
                .HasMany(e => e.Soru)
                .WithRequired(e => e.SoruTip)
                .WillCascadeOnDelete(false);
        }
    }
}
