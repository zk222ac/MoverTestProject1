using MoverTestApp.Interface;
using MoverTestApp.Model;
using System.Collections.Generic;
using System.Linq;

namespace MoverTestApp.Repository
{
    public class InventoryRepository : IInventory
    {
        List<Inventory> lisAllInvent = new List<Inventory>()
        {
            new Inventory(){SKU = 1 , Description = "Inventory 1" , Quantity = 1},
            new Inventory(){SKU = 2 , Description = "Inventory 2" , Quantity = 2},
            new Inventory(){SKU = 3 , Description = "Inventory 3" , Quantity = 4},
            new Inventory(){SKU = 4 , Description = "Inventory 4" , Quantity = 5},
            new Inventory(){SKU = 5 , Description = "Inventory 5" , Quantity = 6}
        };
        public List<Inventory> GetAllInventory()
        {
            return lisAllInvent;
        }

        public Inventory GetInventoryBySku(int sku)
        {
            return lisAllInvent.FirstOrDefault(x => x.SKU == sku);
        }
    }
}
