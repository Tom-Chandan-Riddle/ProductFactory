using ProductFactory.InventoryManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductFactory.InventoryManager.Models
{
    public class Product : IInventoryItem
    {
        public string Name { get; }
        public int Quantity { get; set; }

        public List<IInventoryItem> SubItems { get; } = new List<IInventoryItem>();

        public Product(string name, int qty = 1)
        {
            Name = name;
            Quantity = qty;
        }

        public void AddSubItem(IInventoryItem item)
        {
            SubItems.Add(item);
        }
    }
}
