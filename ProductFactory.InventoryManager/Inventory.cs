using ProductFactory.InventoryManager.Interfaces;
using ProductFactory.InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductFactory.InventoryManager
{
    public class Inventory
    {
        private Dictionary<IInventoryItem, int> inventoryItems = new Dictionary<IInventoryItem, int>();

        public void AddItem(IInventoryItem item, int quantity)
        {
            inventoryItems[item] = quantity;
        }

        public int GetNumberOfCompleteProducts(Product product)
        {
            Dictionary<IInventoryItem, int> componentCounts = new Dictionary<IInventoryItem, int>();

            foreach (var subItem in product.SubItems)
            {
                int count = GetMaxComponentsFromInventory(subItem);
                componentCounts[subItem] = count;
            }

            int numCompleteProducts = int.MaxValue;
            foreach (var component in componentCounts.Keys)
            {
                int numProducts = componentCounts[component];
                if (numProducts < numCompleteProducts)
                {
                    numCompleteProducts = numProducts;
                }
            }

            return numCompleteProducts;
        }

        private int GetMaxComponentsFromInventory(IInventoryItem item)
        {
            if (item is RawMaterial rawMaterial)
            {
                if (!inventoryItems.ContainsKey(rawMaterial))
                {
                    return 0;
                }
                return inventoryItems[rawMaterial] / rawMaterial.Quantity;
            }
            else if (item is Component component)
            {
                int maxComponents = int.MaxValue;
                foreach (var subItem in component.SubItems)
                {
                    int subItemCount = GetMaxComponentsFromInventory(subItem);
                    int requiredQuantity = subItem.Quantity * component.Quantity;
                    int numComponents = subItemCount / requiredQuantity;
                    if (numComponents < maxComponents)
                    {
                        maxComponents = numComponents;
                    }
                }
                return maxComponents;
            }
            else
            {
                throw new InvalidOperationException("Unsupported inventory item type.");
            }
        }
    }
}
