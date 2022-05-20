using Microsoft.EntityFrameworkCore;
using System;
using System.Domain;

namespace System.Persistence
{
    public class SystemDBContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public SystemDBContext(DbContextOptions<SystemDBContext> options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    var FGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
        //    var SGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");

           

        //}
    }
}
