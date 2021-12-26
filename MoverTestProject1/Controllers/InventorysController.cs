using Microsoft.AspNetCore.Mvc;
using MoverTestApp.Interface;
using MoverTestApp.Model;
using MoverTestApp.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoverTestProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventorysController : ControllerBase
    {
        private readonly InventoryRepository _inventoryRepo;
        public InventorysController(InventoryRepository inventoryRepo)
        {
            _inventoryRepo = inventoryRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<Inventory>> GetAllInventory()
        {
            return await _inventoryRepo.GetAllInventory();
        }

        [HttpGet("{sku}")]
        public async Task<ActionResult<Inventory>> GetInventoryById(int sku)
        {
            return await _inventoryRepo.GetInventoryBySku(sku);
        }
    }
}
