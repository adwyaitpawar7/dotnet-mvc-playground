using Microsoft.EntityFrameworkCore;
using MVC_Demo2.Models;

namespace MVC_Demo2.Repository
{
    
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }

    }
}

