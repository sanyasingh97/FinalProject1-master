﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UserProject1.Models
{
    public partial class ProjectTestDataContext : DbContext
    {
        public ProjectTestDataContext()
        {
        }

        public ProjectTestDataContext(DbContextOptions<ProjectTestDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auditoriums> Auditoriums { get; set; }
        public virtual DbSet<BookingDetails> BookingDetails { get; set; }
        public virtual DbSet<Bookings> Bookings { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<MovieDetails> MovieDetails { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Multiplexes> Multiplexes { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; }
     


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=TRD-507;Database=a1;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auditoriums>(entity =>
            {
                entity.HasKey(e => e.AuditoriumId);

                entity.HasIndex(e => e.MultiplexId);

                entity.Property(e => e.AuditoriumName).IsRequired();

                entity.Property(e => e.Time1).IsRequired();

                entity.Property(e => e.Time2).IsRequired();

                entity.Property(e => e.Time3).IsRequired();

                entity.HasOne(d => d.Multiplex)
                    .WithMany(p => p.Auditoriums)
                    .HasForeignKey(d => d.MultiplexId);
            });

            modelBuilder.Entity<BookingDetails>(entity =>
            {
                entity.HasKey(e => new { e.BookingId, e.MovieId });

                entity.HasIndex(e => e.MovieId);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.BookingId);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.MovieId);
            });

            modelBuilder.Entity<Bookings>(entity =>
            {
                entity.HasKey(e => e.BookingId);

                entity.HasIndex(e => e.UserDetailId);

                entity.HasOne(d => d.UserDetail)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserDetailId);
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.Property(e => e.LocationName).IsRequired();
            });

            modelBuilder.Entity<MovieDetails>(entity =>
            {
                entity.HasKey(e => e.MovieDetailId);

                entity.HasIndex(e => e.MovieId)
                    .IsUnique();

                entity.HasOne(d => d.Movie)
                    .WithOne(p => p.MovieDetails)
                    .HasForeignKey<MovieDetails>(d => d.MovieId);
            });

            modelBuilder.Entity<Movies>(entity =>
            {
                entity.HasKey(e => e.MovieId);

                //entity.HasIndex(e => e.AuditoriumId);

                entity.Property(e => e.MovieDuration).IsRequired();

                entity.Property(e => e.MovieName).IsRequired();

                //entity.HasOne(d => d.Auditorium)
                //    .WithMany(p => p.Movies)
                //    .HasForeignKey(d => d.AuditoriumId);
            });

            modelBuilder.Entity<Multiplexes>(entity =>
            {
                entity.HasKey(e => e.MultiplexId);

                entity.HasIndex(e => e.LocationId);

                entity.Property(e => e.MultiplexName).IsRequired();

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Multiplexes)
                    .HasForeignKey(d => d.LocationId);
            });

            modelBuilder.Entity<Payments>(entity =>
            {
                entity.HasKey(e => e.PaymentId);
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.HasKey(e => new { e.UserDetailId, e.MovieId });

                entity.HasIndex(e => e.MovieId)
                    .IsUnique();

                entity.HasIndex(e => e.UserDetailId)
                    .IsUnique();

                entity.HasIndex(e => new { e.MovieId, e.UserDetailId })
                    .HasName("AK_Reviews_MovieId_UserDetailId")
                    .IsUnique();

                entity.HasOne(d => d.Movie)
                    .WithOne(p => p.Reviews)
                    .HasForeignKey<Reviews>(d => d.MovieId);

                entity.HasOne(d => d.UserDetail)
                    .WithOne(p => p.Reviews)
                    .HasForeignKey<Reviews>(d => d.UserDetailId);
            });

            modelBuilder.Entity<UserDetails>(entity =>
            {
                entity.HasKey(e => e.UserDetailId);

                entity.Property(e => e.UserDetailId).HasColumnName("UserDetailID");
            });
        }
    }
}
