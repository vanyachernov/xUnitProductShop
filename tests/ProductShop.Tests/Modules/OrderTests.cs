using ProductShop.Domain.Models;

namespace ProductShop.Tests.Modules;

public class OrderTests
{
    [Fact]
    public void Order_Pay_Success()
    {
        // Arrange (вхідні дані для тестування нашої функції)
        var product = new Product { Id = 1, Name = "Кофе", Price = 10.23m };
        var order = new Order { Id = 1, Product = product, CustomerName = "Ivanov" };

        // Act (тестування/виклик нашої функції)
        order.Pay();

        // Assert
        Assert.True(order.IsPaid);
    }

    [Fact]
    public void CreateOrder_AddedToOrderList()
    {
        // Arrange 
        var products = new Product[]
        {
            new Product { Id = 1, Name = "Кофе", Price = 10.23m },
            new Product { Id = 2, Name = "Молоко", Price = 25.0m}
        };

        var orders = new List<Order>();

        var orderId = orders.Count + 1;

        var product = products[0];

        var order = new Order
        {
            Id = orderId,
            Product = product,
            CustomerName = "Ivanov"
        };

        // Act
        orders.Add(order);

        // Assert
        Assert.Contains(order, orders);
    }
}