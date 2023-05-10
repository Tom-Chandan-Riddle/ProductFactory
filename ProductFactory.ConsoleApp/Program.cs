using ProductFactory.InventoryManager;
using ProductFactory.InventoryManager.Models;

namespace ProductFactory.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //defining the product : A Bike
            var seat = new RawMaterial("seat");
            var pedal = new RawMaterial("pedal", 2);
            var wheelFrame = new RawMaterial("wheelFrame");
            var wheelTube = new RawMaterial("wheelTube");

            var wheel = new Component("wheel", 2);
            wheel.AddSubItem(wheelFrame);
            wheel.AddSubItem(wheelTube);

            var bike = new Product("Bike");
            bike.AddSubItem(seat);
            bike.AddSubItem(pedal);
            bike.AddSubItem(wheel);

            // Create inventory
            var inventory = new Inventory();
            inventory.AddItem(seat, 3);
            inventory.AddItem(pedal, 6);
            inventory.AddItem(wheelTube, 6);
            inventory.AddItem(wheelFrame, 6);

            // Calculate the number of complete products
            int numCompleteProducts = inventory.GetNumberOfCompleteProducts(bike);

            // Display the result
            Console.WriteLine($"Number of Complete Products: {numCompleteProducts}");
            Console.ReadLine();
        }
    }
}