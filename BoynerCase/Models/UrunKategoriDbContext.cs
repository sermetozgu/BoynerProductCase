using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BoynerCase.Models;

public partial class UrunKategoriDbContext : DbContext
{
    public UrunKategoriDbContext()
    {
    }

    public UrunKategoriDbContext(DbContextOptions<UrunKategoriDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kategori> Kategoris { get; set; }

    public virtual DbSet<Urun> Uruns { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\boynerLocalDB; Database=urun_kategori_db;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kategori>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__kategori__3213E83F26F1F3DB");

            entity.ToTable("kategori");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.KategoriIsmi)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("kategori_ismi");
        });

        modelBuilder.Entity<Urun>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__urun__3213E83FF311EAC3");

            entity.ToTable("urun");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Aciklama)
                .HasColumnType("text")
                .HasColumnName("aciklama");
            entity.Property(e => e.KategoriId).HasColumnName("kategori_id");
            entity.Property(e => e.UrunIsmi)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("urun_ismi");

            entity.HasOne(d => d.Kategori).WithMany(p => p.Uruns)
                .HasForeignKey(d => d.KategoriId)
                .HasConstraintName("FK__urun__kategori_i__38996AB5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
