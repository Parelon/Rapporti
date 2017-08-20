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
            builder.Entity<Rapporto>()
                .HasOne(a => a.AutoreUtente)
                .WithOne()
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict);
            builder.Entity<Rapporto>()
                .HasOne(a => a.DestinatarioUtente)
                .WithOne()
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict);
        }

        public virtual DbSet<Gruppo> Gruppi { get; set; }
        public virtual DbSet<Assegnazione> Assegnazioni { get; set; }
        public virtual DbSet<Rapporto> Rapporti { get; set; }
    }
}
