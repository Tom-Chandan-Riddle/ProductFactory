using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductFactory.InventoryManager.Interfaces
{
    public interface IInventoryItem
    {
        string Name { get; }
        int Quantity { get; }
    }
}
