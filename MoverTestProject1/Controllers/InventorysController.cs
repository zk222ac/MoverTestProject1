using Microsoft.AspNetCore.Mvc;
using MoverTestApp.Interface;
using MoverTestApp.Model;
using MoverTestApp.Repository;
using System.Collections.Generic;

namespace MoverTestProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventorysController : ControllerBase
    {
        private IInventory inventory = new InventoryRepository();

        [HttpGet]
        public ActionResult<List<Inventory>> GetAllInventory()
        {
            return inventory.GetAllInventory();
        }

        [HttpGet("{sku}")]
        public ActionResult<Inventory> GetInventoryById(int sku)
        {
            return inventory.GetInventoryBySku(sku);
        }
    }
}
