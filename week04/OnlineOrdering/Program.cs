using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("482 Maple Street", "Boise", "ID", "USA");
        Customer customer1 = new Customer("John Carter", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "WM-1021", 18.99, 2));
        order1.AddProduct(new Product("USB-C Cable", "UC-3300", 7.50, 3));
        order1.AddProduct(new Product("Laptop Stand", "LS-4410", 29.95, 1));

        Address address2 = new Address("Av. Madero 215", "Morelia", "Michoacan", "Mexico");
        Customer customer2 = new Customer("Maria Lopez", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Notebook Pack", "NB-0505", 6.25, 4));
        order2.AddProduct(new Product("Desk Lamp", "DL-7712", 24.00, 1));

        List<Order> orders = new List<Order> { order1, order2 };

        int number = 1;
        foreach (Order order in orders)
        {
            Console.WriteLine($"Order {number}");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();
            Console.WriteLine($"Total Price: ${order.GetTotalPrice():0.00}");
            Console.WriteLine("----------------------------------------");
            number++;
        }
    }
}
