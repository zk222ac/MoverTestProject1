using Microsoft.AspNetCore.JsonPatch;
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
        private readonly IInventoryRepository _inventoryRepo;
        public InventorysController(IInventoryRepository inventoryRepo)
        {
            _inventoryRepo = inventoryRepo;
        }
        [HttpGet]
        public async Task<IEnumerable<Inventory>> GetInventorys()
        {
            return await _inventoryRepo.Get();
        }
        [HttpGet("{sku}")]
        public async Task<ActionResult<Inventory>> GetInventorys(int sku)
        {
            return await _inventoryRepo.Get(sku);
        }

        [HttpPost]
        public async Task<ActionResult<Inventory>> CreateInventoryUnknownSku([FromBody] Inventory invent)
        {
            var newInvent = await _inventoryRepo.CreateInventoryUnknownSku(invent);
            return CreatedAtAction(nameof(GetInventorys), new { sku = newInvent.SKU }, newInvent);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateInventory(int sku, [FromBody] Inventory invent)
        {
            if (sku != invent.SKU)
            {
                return BadRequest();
            }

            await _inventoryRepo.Update(invent);
            return NoContent();
        }
        [HttpDelete("{sku}")]
        public async Task<ActionResult> DeleteInventory(int sku)
        {
            // check inventory exist in the database
            var inventToDelete = await _inventoryRepo.Get(sku);
            if (inventToDelete == null)
            {
                return NotFound();
            }
            await _inventoryRepo.DeleteInventory(inventToDelete.SKU);
            return NoContent();
        }

        [HttpGet]
        [Route("Hours/{hour}/Minutes/{minutes}")]
        public async Task<ActionResult<double>> CreateLeastAngleWatchHands(int hour, int minutes)
        {
            var angle = await Angle.AngleClock(hour, minutes);
            return angle;
        }

        [HttpPatch("{sku}")]
        public async Task<IActionResult> UpdateQuantityPatch([FromBody] JsonPatchDocument jpd , [FromRoute] int sku) 
        {
            await _inventoryRepo.UpdateQuantityPatchAsync(sku, jpd);
            return Ok();        
        }
    }
}
