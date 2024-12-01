﻿using CarRendalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRendalAPI.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSets for each of your entities
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<CarImages> CarImages { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ServiceRecord> ServiceRecords { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        // Configure relationships and model properties
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Car-Model relationship: One-to-many
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Model)
                .WithMany(m => m.Cars)
                .HasForeignKey(c => c.ModelId)
                .OnDelete(DeleteBehavior.Cascade);

            // Model-Brand relationship: One-to-many
            modelBuilder.Entity<Model>()
                .HasOne(c => c.Brand)
                .WithMany(m => m.Models)
                .HasForeignKey(c => c.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

            // User-Image relationship: One-to-many
            //modelBuilder.Entity<UserImages>()
            //    .HasOne(i => i.User)
            //    .WithMany(u => u.Images)
            //    .HasForeignKey(i => i.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);

            // Car-Image relationship: One-to-many
            modelBuilder.Entity<CarImages>()
                .HasOne(i => i.Car)
                .WithMany(c => c.CarImages)
                .HasForeignKey(i => i.CarId)
                .OnDelete(DeleteBehavior.Cascade);

            // Reservations-User relationship: Many-to-one (reservation made by a user)
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Reservation-Car relationship: Many-to-one (reservation for a car)
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Car)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.CarId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Car)           // Rental has one Car
                .WithMany(c => c.Rentals)     // Car has many Rentals
                .HasForeignKey(r => r.CarId) // Foreign key in Rental
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.User)          // Rental has one User
                .WithMany(u => u.Rentals)     // User has many Rentals
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //// Payment-Reservation relationship: One-to-one (one payment per reservation)
            //modelBuilder.Entity<Payment>()
            //    .HasOne(p => p.Reservation)
            //    .WithOne(r => r.Payment)
            //    .HasForeignKey<Payment>(p => p.ReservationId)
            //    .OnDelete(DeleteBehavior.Cascade);

            // Review-Car relationship: One-to-many
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Car)
                .WithMany(c => c.Reviews)
                .HasForeignKey(r => r.CarId)
                .OnDelete(DeleteBehavior.Cascade);

            // ServiceRecord-Car relationship: One-to-many
            modelBuilder.Entity<ServiceRecord>()
                .HasOne(s => s.Car)
                .WithMany(c => c.ServiceRecords)
                .HasForeignKey(s => s.CarId)
                .OnDelete(DeleteBehavior.Cascade);

            //Address - User relationship: One - to - one
            modelBuilder.Entity<Address>()
                .HasOne(a => a.User)
                .WithOne(u => u.Address)
                .HasForeignKey<Address>(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Notification-User relationship: One-to-many
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
