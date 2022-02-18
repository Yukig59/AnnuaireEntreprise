using Annuaire.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annuaire.Contexts
{
    class DatabaseContext : DbContext
    {
        #region Ctor
        public DatabaseContext() : base()
        {                   
        }
        #endregion
        #region DBsets
        public DbSet<Services>? Service { get; set; }
        public DbSet<Sites>? Site { get; set; }
        public DbSet<Salaries>? Salarie { get; set; }

        #endregion
        #region Config

        public static string GetConnectionString()
        {
            return "Server=(localdb)\\MSSQLLocalDB;Database=Annuaire;Trusted_Connection=True;MultipleActiveResultSets=true";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                var _connectionString = GetConnectionString();
                optionsBuilder.UseSqlServer(_connectionString);
                optionsBuilder.EnableSensitiveDataLogging();
            }
            base.OnConfiguring(optionsBuilder);
        }

        #endregion

        #region Mapping
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Services
            modelBuilder.Entity<Services>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });
            #endregion
            #region Sites
            modelBuilder.Entity<Sites>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Ville).IsRequired();
            });

            #endregion
            #region Salariés
            modelBuilder.Entity<Salaries>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nom).IsRequired();
                entity.Property(e => e.Prenom).IsRequired();
                entity.Property(e => e.TelPortable).IsRequired();
                entity.Property(e => e.TelFixe).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.HasOne(d => d.Services).WithMany(p => p.Salaries);
                entity.HasOne(d => d.Site).WithMany(p => p.Salaries);
            });
            #endregion


        }
        #endregion
    }
}
