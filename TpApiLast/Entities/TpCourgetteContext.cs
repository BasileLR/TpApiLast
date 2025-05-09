using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TpApiLast.Entities;

public partial class TpCourgetteContext : DbContext
{
    public TpCourgetteContext()
    {
    }

    public TpCourgetteContext(DbContextOptions<TpCourgetteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bot> Bots { get; set; }

    public virtual DbSet<Calcul> Calculs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=BLIZZARD\\MSSQLSERVER01;Database=TpCourgette;User=blizzard2;Password=blizzard2;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bot>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BotName)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.EnrollmentDate)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.FirstName)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Calcul>(entity =>
        {
            entity.ToTable("calcul");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Kc)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("kc");
            entity.Property(e => e.SurfaceCulture)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("surfaceCulture");
            entity.Property(e => e.VolumeReserveEau)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("volumeReserveEau");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
