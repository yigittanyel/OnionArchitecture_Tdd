using Microsoft.EntityFrameworkCore;
using OnArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnArch.Persistance.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id=Guid.NewGuid(),Name="Book",Stock=100,Value=5,CreatedDate=DateTime.Now},
                new Product { Id=Guid.NewGuid(),Name="Pencil",Stock=200,Value=10,CreatedDate=DateTime.Now},
                new Product { Id=Guid.NewGuid(),Name="Eraser",Stock=300,Value=15,CreatedDate=DateTime.Now}
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
