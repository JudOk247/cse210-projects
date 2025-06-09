using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create customers
        var customer1 = new Customer("John Doe", new Address("123 Main St", "Anytown", "CA", "USA"));
        var customer2 = new Customer("Jane Smith", new Address("456 Elm St", "Othertown", "ON", "Canada"));

        // Create orders
        var order1 = new Order(customer1);
        order1.AddProduct(new Product("Product A", "A123", 10.99m, 2));
        order1.AddProduct(new Product("Product B", "B456", 5.99m, 3));
        order1.AddProduct(new Product("Product C", "C789", 7.99m, 1));

        var order2 = new Order(customer2);
        order2.AddProduct(new Product("Product D", "D012", 12.99m, 1));
        order2.AddProduct(new Product("Product E", "E345", 8.99m, 2));

        // Display order information
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():F2}");
        Console.WriteLine();

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():F2}");
    }
}