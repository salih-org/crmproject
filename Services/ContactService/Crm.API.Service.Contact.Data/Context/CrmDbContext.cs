using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Crm.API.Service.Contact.Data.Models;

namespace Crm.API.Service.Contact.Data.Context
{
    public partial class CrmDbContext : DbContext
    {
        public CrmDbContext()
        {
        }

        public CrmDbContext(DbContextOptions<CrmDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Models.Contact> Contact { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Contact>(entity =>
            {
                entity.ToTable("contact", "contact");

                entity.HasIndex(e => e.Id)
                    .HasName("contact_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
