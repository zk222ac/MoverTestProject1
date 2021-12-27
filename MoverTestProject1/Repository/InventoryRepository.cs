using MoverTestApp.Interface;
using MoverTestApp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MoverTestApp.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        //List<Inventory> lisAllInvent = new List<Inventory>()
        //{
        //    new Inventory(){SKU = 1 , Description = "Inventory 1" , Quantity = 1},
        //    new Inventory(){SKU = 2 , Description = "Inventory 2" , Quantity = 2},
        //    new Inventory(){SKU = 3 , Description = "Inventory 3" , Quantity = 4},
        //    new Inventory(){SKU = 4 , Description = "Inventory 4" , Quantity = 5},
        //    new Inventory(){SKU = 5 , Description = "Inventory 5" , Quantity = 6}
        //};
        private readonly InventoryContext _context;
        public InventoryRepository(InventoryContext context)
        {
            _context = context;
        }

        public Task<Inventory> CreateInventoryKnownSku(int sku, Inventory inventory)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Inventory> CreateInventoryUnknownSku(Inventory inventory)
        {
            _context.Inventorys.Add(inventory);
            await _context.SaveChangesAsync();
            return inventory;
        }

        public async Task<IEnumerable<Inventory>> Get()
        {
            return await _context.Inventorys.ToListAsync();
        }

        public async Task<Inventory> Get(int sku)
        {
            return await _context.Inventorys.FindAsync(sku);
        }
        public async Task DeleteInventory(int sku)
        {
            var removeDefinedQuantityBySpecificSku = await _context.Inventorys.FindAsync(sku);
            _context.Inventorys.Remove(removeDefinedQuantityBySpecificSku);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Inventory Invent)
        {
            _context.Entry(Invent).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
    }
}
