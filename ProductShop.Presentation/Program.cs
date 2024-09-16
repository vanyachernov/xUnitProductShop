using ProductShop.Domain.Models;

class Program
{
    private static List<Product> _products =
    [
        new Product { Id = 1, Name = "Кульки з молоком", Price = 10.0m },
        new Product { Id = 2, Name = "Кока-кола", Price = 20.0m }
    ];

    private static List<Order> _orders = [];

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1. View Products");
            Console.WriteLine("2. Create Order");
            Console.WriteLine("3. Pay for Order");
            Console.WriteLine("4. Deliver Order");
            Console.WriteLine("5. Exit");

            Console.Write("Your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewProducts();
                    break;
                case "2":
                    CreateOrder();
                    break;
                case "3":
                    PayOrder();
                    break;
                case "4":
                    DeliverOrder();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("\nInvalid choice.");
                    break;
            }
        }
    }
    
    private static void ViewProducts()
    {
        Console.WriteLine("\nProducts:");
        foreach (var product in _products)
        {
            Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
        }
        Console.WriteLine();
    }
    
    private static void CreateOrder()
    {
        Console.WriteLine("Enter Product Id:");
        var productId = Convert.ToInt32(Console.ReadLine());
            
        Console.WriteLine("Enter Customer Name:");
        var customerName = Console.ReadLine();

        var product = _products.FirstOrDefault(p => p.Id == productId);
            
        if (product == null)
        {
            Console.WriteLine("\nProduct not found.");
            return;
        }

        var order = new Order
        {
            Id = _orders.Count + 1,
            Product = product,
            CustomerName = customerName!
        };

        _orders.Add(order);
            
        Console.WriteLine($"Order created: Id = {order.Id}, Product = {order.Product.Name}, Customer = {order.CustomerName}.");
    }
    
    private static void PayOrder()
    {
        Console.WriteLine("Enter Order Id:");
        var orderId = Convert.ToInt32(Console.ReadLine());

        var order = _orders.FirstOrDefault(o => o.Id == orderId);
            
        if (order == null)
        {
            Console.WriteLine("Order not found.");
            return;
        }

        try
        {
            order.Pay();
            Console.WriteLine("\nOrder paid successfully.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }
    }
    
    private static void DeliverOrder()
    {
        Console.WriteLine("Enter Order Id:");
        var orderId = Convert.ToInt32(Console.ReadLine());

        var order = _orders.FirstOrDefault(o => o.Id == orderId);
        
        if (order == null)
        {
            Console.WriteLine("Order not found.");
            return;
        }

        try
        {
            order.Deliver();
            Console.WriteLine("\nOrder delivered successfully.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }
    }
}