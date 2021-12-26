using MoverTestApp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoverTestApp.Interface
{
   public interface IInventory
    {
        // List of all inventory
        Task<IEnumerable<Inventory>> GetAllInventory();
        // Get inventory by specific sku 
        Task<Inventory> GetInventoryBySku(int sku);

        // Adding inventory with unknown SKU, it should create new.
        Task<Inventory> CreateInventoryUnknownSku(Inventory inventory);

        //Adding inventory with known SKU, it should add the quantity to existing
        Task<Inventory> CreateInventoryKnownSku(int sku , Inventory inventory);

        // Remove a defined quantity for a specific SKU
        Task RemoveQuantitySku(int sku);
    }
}
