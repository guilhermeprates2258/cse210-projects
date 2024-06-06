using System;
using System.Collections.Generic;

class Product
{
    public string Name { get; private set; }
    public string ProductId { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }

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
}

class Address
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }

    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    public bool IsInUSA()
    {
        return Country.ToLower() == "usa";
    }

    public override string ToString()
    {
        return $"{Street}\n{City}, {State}\n{Country}";
    }
}

class Customer
{
    public string Name { get; private set; }
    public Address Address { get; private set; }

    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    public bool LivesInUSA()
    {
        return Address.IsInUSA();
    }
}

class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer, List<Product> products)
    {
        this.customer = customer;
        this.products = products;
    }

    public decimal GetTotalCost()
    {
        decimal totalCost = 0;
        foreach (var product in products)
        {
            totalCost += product.GetTotalCost();
        }

        totalCost += customer.LivesInUSA() ? 5 : 35;
        return totalCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (var product in products)
        {
            packingLabel += $"{product.Name} (ID: {product.ProductId})\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.Name}\n{customer.Address}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("123 Main St", "Anytown", "UT", "USA");
        Address address2 = new Address("456 Elm St", "Othertown", "ON", "Canada");

        // Create customers
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create products
        Product product1 = new Product("Laptop", "P001", 999.99m, 1);
        Product product2 = new Product("Mouse", "P002", 25.50m, 2);
        Product product3 = new Product("Keyboard", "P003", 45.00m, 1);
        Product product4 = new Product("Monitor", "P004", 150.00m, 2);

        // Create orders
        List<Product> products1 = new List<Product> { product1, product2 };
        List<Product> products2 = new List<Product> { product3, product4 };

        Order order1 = new Order(customer1, products1);
        Order order2 = new Order(customer2, products2);

        // Display order details
        List<Order> orders = new List<Order> { order1, order2 };

        foreach (var order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order.GetTotalCost():F2}\n");
        }
    }
}
