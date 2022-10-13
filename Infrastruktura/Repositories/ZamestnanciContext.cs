using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Infrastruktura.Models;
#nullable disable

namespace Infrastruktura.Repositories
{
    public partial class EmployeesDbContext : DbContext
    {


        public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<LastPositions> LastPositions { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

        modelBuilder.Entity<Positions>(entity =>
        {

        entity.ToTable("Positions");
        entity.HasKey(e => e.PositionId);
               
        entity.Property(e => e.PositionName)
            .HasMaxLength(255)
            .IsUnicode(false);

        entity.Property(e => e.PositionId).HasColumnName("PositionId");
        });

        modelBuilder.Entity<LastPositions>(entity =>
        {

        entity.HasKey(e => e.LastPositionId);

        entity.ToTable("LastPositions");

        entity.HasOne(e => e.Positions)
                .WithMany()
                .HasForeignKey(x => x.PositionId);

        entity.Property(e => e.DateOfEntry)
            .HasColumnType("date")
            .HasColumnName("dateOfEntry");

        entity.Property(e => e.DateOfLeave)
            .HasColumnType("date")
            .HasColumnName("dateOfLeave");

        entity.Property(e => e.PositionId).HasColumnName("positionId");

        entity.Property(e => e.EmployeeId).HasColumnName("employeeId");

        });

            modelBuilder.Entity<Employees>(entity =>
            {


            entity.HasKey(e => e.EmployeeId);

            entity.HasOne(e => e.Positions)
                .WithMany()
                .HasForeignKey(x => x.PositionId);
                
                entity.Property(e => e.Adress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("adress");

                entity.Property(e => e.Archived).HasColumnName("archived");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.DateOfEntry).HasColumnType("date");

                entity.Property(e => e.PositionId).HasColumnName("positionId");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeId");
            });
              
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        


    }
}