namespace CleanCodeLesson.Encapsulation.GoodOrder;

public class Order
{
    public Guid Id { get; set; }

    public bool IsProcessed { get; set; }
    
    public int TotalPrice { get; set; }
    
    public IList<OrderLine> OrderLines { get; set; }
}

public class OrderLine
{
    public Guid Id { get; set; }
    
    public int Price { get; set; }
}

public interface IOrderCalculator
{
    public void CalculateTotalPrice(Order order);
}

public class OrderCalculationService : IOrderCalculator
{
    public void CalculateTotalPrice(Order order)
    {
        order.TotalPrice = order.OrderLines.Sum(z => z.Price);
    }
}