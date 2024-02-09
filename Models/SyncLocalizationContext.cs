using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerWithLocalization.Models;

public partial class SyncLocalizationContext : DbContext
{
    public SyncLocalizationContext()
    {
    }

    public SyncLocalizationContext(DbContextOptions<SyncLocalizationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Table> Tables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SyncLocalization;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PK_TaskData");

            entity.ToTable("Table");

            entity.Property(e => e.Key)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.De)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("de");
            entity.Property(e => e.EnUs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("en-US");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
