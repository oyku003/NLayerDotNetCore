using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyNLayer.Data.Configurations;
using UdemyNLayer.Data.Seeds;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1,2}));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2 }));
        }
    }
}
