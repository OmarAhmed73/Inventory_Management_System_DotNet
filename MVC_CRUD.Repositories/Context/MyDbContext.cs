using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Entities.Models;

namespace MVC_CRUD.Repositories.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<StockAlert> StockAlerts { get; set; }

        public DbSet<Inventory> Inventorys { get; set; }

    }

}
