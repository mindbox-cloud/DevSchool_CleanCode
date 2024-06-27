namespace CleanCodeLesson.Examples.Abstraction;

public record Customer(Guid Id, string Name, string? Address, decimal TotalMoneySpent);

public record Dish(Guid Id, string Name, decimal Price);

public record Order(Guid Id, Guid CustomerId, decimal TotalPrice);

public class OrdersProcessor
{
    private readonly ICustomerRepository _customerRepository;

    public OrdersProcessor(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Order> CreateOnlineOrder(Guid customerId, IEnumerable<Dish> dishes)
    {
        var customer = await _customerRepository.GetById(customerId);

        if (customer.Address == null) throw new ArgumentNullException(customer.Address);
        
        var sum = dishes.Sum(z => z.Price);
        if (customer.TotalMoneySpent > 2000) sum *= 0.9m;

        if (customer.TotalMoneySpent > 5000) sum *= 0.8m;

        sum *= 1.1m;

        return new Order(Guid.NewGuid(), customerId, sum);
    }

    public async Task<Order> CreateOfflineOrder(Guid customerId, IEnumerable<Dish> dishes)
    {
        var customer = await _customerRepository.GetById(customerId);

        var sum = dishes.Sum(z => z.Price);
        if (customer.TotalMoneySpent > 2000) sum *= 0.9m;

        if (customer.TotalMoneySpent > 5000) sum *= 0.8m;

        return new Order(Guid.NewGuid(), customerId, sum);
    }

    private static void ValidateCustomer(Customer customer)
    {
        if (customer.Address == null) throw new ArgumentNullException(customer.Address);
    }
}