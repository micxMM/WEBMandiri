using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WEBMandiri.Models;

public partial class TestMandiriContext : DbContext
{
    public TestMandiriContext()
    {
    }

    public TestMandiriContext(DbContextOptions<TestMandiriContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Transaksi> Transaksis { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   => optionsBuilder.UseSqlServer("Server=localhost;Database=TestMandiri;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaksi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__transaks__3213E83F2AB0DF7F");

            entity.ToTable("transaksi");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Jumlah).HasColumnName("jumlah");
            entity.Property(e => e.NamaBarang)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("namaBarang");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Transaksis)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__transaksi__idUse__398D8EEE");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F8704C9C6");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Domisili)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("domisili");
            entity.Property(e => e.Nama)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nama");
            entity.Property(e => e.Pekerjaan)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pekerjaan");
            entity.Property(e => e.Umur).HasColumnName("umur");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
