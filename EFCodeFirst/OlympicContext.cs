using EFCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCodeFirst
{
    public class OlympicContext : DbContext
    {
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Sportsman> Sportsmen { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Medal> Medals { get; set; }
        public DbSet<SportSportsman> SportSportsmen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Olympic; Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sportsman>()
                .HasKey(s => s.SportsmanId);
            modelBuilder.Entity<Sportsman>()
                .Property(s => s.FirstName)
                .IsRequired();
            modelBuilder.Entity<Sportsman>()
                .Property(s => s.LastName)
                .IsRequired();

            modelBuilder.Entity<Sport>()
                .HasKey(s => s.SportId);
            modelBuilder.Entity<Sport>()
                .Property(s => s.Title)
                .IsRequired();

            modelBuilder.Entity<Country>()
                .HasKey(c => c.CountryId);
            modelBuilder.Entity<Country>()
                .Property(c => c.Name)
                .IsRequired();

            modelBuilder.Entity<SportSportsman>()
                .HasKey(ss => ss.Id);

            modelBuilder.Entity<Medal>()
                .HasKey(m => m.Id);
        }
    }
}
