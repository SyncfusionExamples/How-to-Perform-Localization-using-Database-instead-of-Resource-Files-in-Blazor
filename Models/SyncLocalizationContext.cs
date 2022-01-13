using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BlazorServer.Models
{
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

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SyncLocalization;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Table>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PK__Table__C41E0288DDDB2827");

                entity.ToTable("Table");

                entity.Property(e => e.Key).HasMaxLength(50);

                entity.Property(e => e.De).HasColumnName("de");

                entity.Property(e => e.EnUs).HasColumnName("en-US");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
