using ProductFactory.InventoryManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductFactory.InventoryManager.Models
{
    public class RawMaterial : IInventoryItem
    {
        public string Name { get; }
        public int Quantity { get; set; }
        public RawMaterial(string name, int qty = 1)
        {
            Name = name;
            Quantity = qty;
        }
    }
}
