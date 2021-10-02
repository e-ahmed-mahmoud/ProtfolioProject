using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CoreLayer.Models;

namespace DAL
{
    public class PortDbContext : DbContext 
    {
        public PortDbContext( DbContextOptions<PortDbContext> options ) : base (options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Owner>().Property(o => o.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<PortfoloItem>().Property(p => p.Id).HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Owner>().HasData(new Owner { Id = Guid.NewGuid(), ImagePath = "avater", Name = "Ahmed Mahmoud", Profile = "Ahmed/linkedIn" });
        }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<PortfoloItem> PortfoloItems { get; set; }
    }
}
