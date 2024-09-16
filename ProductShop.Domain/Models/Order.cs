namespace ProductShop.Domain.Models;

public class Order
{
    public int Id { get; set; }
    public Product Product { get; set; } = default!;
    public string CustomerName { get; set; } = default!;

    public decimal TotalPrice => Product.Price;
    public bool IsPaid { get; set; } = false;
    public bool IsDelivered { get; set; } = false;

    public void Pay()
    {
        if (IsPaid)
        {
            throw new InvalidOperationException("Order is already paid");
        }
        
        // other logic so far..
        
        IsPaid = true;
    }

    public void Deliver()
    {
        if (!IsPaid)
        {
            // other logic so far..
            throw new InvalidOperationException("Order must be paid before delivery.");
        }
        
        if (IsDelivered)
        {
            // other logic so far..
            throw new InvalidOperationException("Order is already delivered.");
        }

        // other logic so far..
        
        IsDelivered = true;
    }
}