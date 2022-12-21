using Api_Demo_Project.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api_Demo_Project.DAL.Context
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-T0I7RRL;initial catalog=ApiDb; integrated security=true");

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
