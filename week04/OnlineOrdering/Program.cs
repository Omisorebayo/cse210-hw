using System;

class Program
{
    static void Main(string[] args)
    {
        // ==========================
        // Order 1 (Customer in USA)
        // ==========================
        Address address1 = new Address(
            "123 Main Street",
            "Dallas",
            "Texas",
            "USA"
        );

        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop", "P1001", 800.00, 1));
        order1.AddProduct(new Product("Wireless Mouse", "P1002", 25.00, 2));
        order1.AddProduct(new Product("Keyboard", "P1003", 45.00, 1));

        // ==========================
        // Order 2 (Customer outside USA)
        // ==========================
        Address address2 = new Address(
            "45 King Street",
            "Toronto",
            "Ontario",
            "Canada"
        );

        Customer customer2 = new Customer("Mary Brown", address2);

        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Printer", "P2001", 220.00, 1));
        order2.AddProduct(new Product("Printer Paper", "P2002", 12.00, 5));

        // ==========================
        // Display Orders
        // ==========================

        DisplayOrder(order1, 1);

        Console.WriteLine();

        DisplayOrder(order2, 2);
    }

    static void DisplayOrder(Order order, int orderNumber)
    {
        Console.WriteLine($"========== ORDER {orderNumber} ==========\n");

        Console.WriteLine("PACKING LABEL");
        Console.WriteLine(order.GetPackingLabel());

        Console.WriteLine("------------------------------");

        Console.WriteLine("SHIPPING LABEL");
        Console.WriteLine(order.GetShippingLabel());

        Console.WriteLine("------------------------------");

        Console.WriteLine($"Total Price: ${order.CalculateTotal():F2}");
    }
}