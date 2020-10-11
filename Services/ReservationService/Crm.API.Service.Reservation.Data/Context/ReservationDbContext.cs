using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Crm.API.Service.Reservation.Data.Models;

namespace Crm.API.Service.Reservation.Data.Context
{
    public partial class ReservationDbContext : DbContext
    {
        public ReservationDbContext()
        {
        }

        public ReservationDbContext(DbContextOptions<ReservationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Reservations> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservations>(entity =>
            {
                entity.ToTable("reservations", "reservations");

                entity.HasIndex(e => e.Id)
                    .HasName("reservations_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CheckIn)
                    .HasColumnName("check_in")
                    .HasColumnType("date");

                entity.Property(e => e.CheckOut)
                    .HasColumnName("check_out")
                    .HasColumnType("date");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.ResNumber)
                    .HasColumnName("res_number")
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
