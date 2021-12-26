using MoverTestApp.Model;
using System.Collections.Generic;

namespace MoverTestApp.Interface
{
   public interface IInventory
    {
        List<Inventory> GetAllInventory();
        Inventory GetInventoryBySku(int sku);
    }
}
