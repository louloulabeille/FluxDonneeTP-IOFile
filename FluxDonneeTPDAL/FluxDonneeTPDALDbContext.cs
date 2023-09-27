using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FluxDonneeTPDAL;

public partial class FluxDonneeTPDALDbContext : DbContext
{
    public FluxDonneeTPDALDbContext()
    {
    }

    public FluxDonneeTPDALDbContext(DbContextOptions<FluxDonneeTPDALDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Personne> Personnes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=ApprendreCsharp;User Id=sa;Password=ieupn486jadF&;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Personne>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Personne__3214EC076255FCE3");

            entity.Property(e => e.Nom).HasMaxLength(256);
            entity.Property(e => e.Prenom).HasMaxLength(256);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
