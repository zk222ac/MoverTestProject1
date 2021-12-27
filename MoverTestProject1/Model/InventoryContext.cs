using Microsoft.EntityFrameworkCore;
namespace MoverTestApp.Model
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {
            Database.EnsureCreatedAsync();
        }

        public DbSet<Inventory> Inventorys { get; set; }
    }
}
