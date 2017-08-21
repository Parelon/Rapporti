using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rapporti.Models;

namespace Rapporti.Data
{
    public class ApplicationDbContext : IdentityDbContext<Utente, Ruolo, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Assegnazione>().HasIndex(a => a.GruppoId).IsUnique(false);
            builder.Entity<Assegnazione>().HasIndex(a => a.UtenteId).IsUnique(false);
            builder.Entity<Compito>().HasIndex(c => c.GruppoId).IsUnique(false);
            builder.Entity<Compito>().HasIndex(c => c.UtenteId).IsUnique(false);
            builder.Entity<Rapporto>().HasIndex(r => r.AutoreId).IsUnique(false);
            builder.Entity<Rapporto>().HasIndex(r => r.DestinatarioId).IsUnique(false);
            builder.Entity<Rapporto>().HasIndex(r => r.GruppoId).IsUnique(false);
            //builder.Entity<Rapporto>().Property(r => r.DestinatarioUtenteId).IsRequired(false);

            //builder.Entity<Rapporto>().HasOne(typeof(Utente), "AutoreUtenteId").WithMany("RapportiScritti").HasForeignKey("AutoreUtenteId").HasPrincipalKey("Id");
            //builder.Entity<Rapporto>().HasOne(typeof(Utente), "DestinatarioUtenteId").WithMany("RapportiRicevuti").HasForeignKey("DestinatarioUtenteId").HasPrincipalKey("Id");

            //builder.Entity<Rapporto>()
            //    .HasOne("AutoreUtenteId")
            //    .WithOne()
            //    .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict);

            //builder.Entity<Rapporto>()
            //    .HasOptional("DestinatarioUtenteId")
            //    .WithOne()
            //    .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict);
        }

        public virtual DbSet<Gruppo> Gruppi { get; set; }
        public virtual DbSet<Assegnazione> Assegnazioni { get; set; }
        public virtual DbSet<Rapporto> Rapporti { get; set; }
        public virtual DbSet<Compito> Compiti { get; set; }
    }
}
