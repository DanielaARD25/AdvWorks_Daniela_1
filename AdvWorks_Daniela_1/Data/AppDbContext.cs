using AdvWorks_Daniela_1.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvWorks_Daniela_1.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}

        public DbSet<SalesTerritory> SalesTerritory { get; set; }
    }
}
