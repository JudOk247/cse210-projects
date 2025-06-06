using System;
using System.Collections.Generic;

// Define the Address class
public class Address
{
    private string StreetAddress { get; set; }
    private string City { get; set; }
    private string StateProvince { get; set; }
    private string Country { get; set; }

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        StreetAddress = streetAddress;
        City = city;
        StateProvince = stateProvince;
        Country = country;
    }

    public bool IsInUSA()
    {
        return Country.ToLower() == "usa";
    }

    public override string ToString()
    {
        return $"{StreetAddress}\n{City}, {StateProvince}\n{Country}";
    }
}

// Define the Customer class
public class Customer
{
    private string Name { get; set; }
    private Address Address { get; set; }

    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    public bool IsInUSA()
    {
        return Address.IsInUSA();
    }

    public string GetName()
    {
        return Name;
    }

    public Address GetAddress()
    {
        return Address;
    }
}

// Define the Product class
public class Product
{
    private string Name { get; set; }
    private string ProductId { get; set; }
    private decimal Price { get; set; }
    private int Quantity { get; set; }

    public Product(string name, string productId, decimal price, int quantity)
    {
        Name = name;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }

    public decimal GetTotalCost()
    {
        return Price * Quantity;
    }

    public string GetName()
    {
        return Name;
    }

    public string GetProductId()
    {
        return ProductId;
    }
}

// Define the Order class
public class Order
{
    private List<Product> Products { get; set; }
    private Customer Customer { get; set; }

    public Order(Customer customer)
    {
        Products = new List<Product>();
        Customer = customer;
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public decimal GetTotalPrice()
    {
        decimal productCost = 0;
        foreach (var product in Products)
        {
            productCost += product.GetTotalCost();
        }

        decimal shippingCost = Customer.IsInUSA() ? 5 : 35;
        return productCost + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in Products)
        {
            label += $"{product.GetName()} - {product.GetProductId()}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{Customer.GetName()}\n{Customer.GetAddress().ToString()}";
    }
}

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