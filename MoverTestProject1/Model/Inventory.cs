using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MoverTestApp.Model
{
    
    public class Inventory
    {
        [Key]
        public int SKU { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }

    }
}
