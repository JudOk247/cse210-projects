using System;

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