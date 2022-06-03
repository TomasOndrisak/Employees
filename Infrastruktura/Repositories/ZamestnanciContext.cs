using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Infrastruktura.Models;
#nullable disable

namespace Infrastruktura.Repositories
{
    public partial class ZamestnanciContext : DbContext
    {


        public ZamestnanciContext(DbContextOptions<ZamestnanciContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pozicie> Pozicie { get; set; }
        public virtual DbSet<PredoslePozicie> Predoslepozicie { get; set; }
        public virtual DbSet<Zamestnanci> Zamestnanci { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Pozicie>(entity =>
            {

                entity.ToTable("Pozicie");
                entity.HasKey(e => e.PoziciaId);
                entity.Property(e => e.NazovPozicie)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PoziciaId).HasColumnName("PoziciaID");
            });

            modelBuilder.Entity<PredoslePozicie>(entity =>
            {
                entity.HasKey(e => e.IDPredoslej);

                entity.ToTable("PredoslePozicie");



                entity.Property(e => e.DatumNastupu)
                    .HasColumnType("date")
                    .HasColumnName("datumNastupu");

                entity.Property(e => e.DatumUkoncenia)
                    .HasColumnType("date")
                    .HasColumnName("datumUkoncenia");

                entity.Property(e => e.PoziciaId).HasColumnName("poziciaId");

                entity.Property(e => e.ZamestnanecId).HasColumnName("ZamestnanecId");
            });

            modelBuilder.Entity<Zamestnanci>(entity =>
            {
                entity.HasKey(e => e.ZamestnanecId);
                entity.ToTable("Zamestnanci");

                entity.Property(e => e.Adresa)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("adresa");

                entity.Property(e => e.Archivovany).HasColumnName("archivovany");

                entity.Property(e => e.DatumNarodenia).HasColumnType("date");

                entity.Property(e => e.DatumNastupu).HasColumnType("date");

                entity.Property(e => e.IdPozicie).HasColumnName("idPozicie");

                entity.Property(e => e.Meno)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Priezvisko)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ZamestnanecId).HasColumnName("ZamestnanecID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);




    }
}
