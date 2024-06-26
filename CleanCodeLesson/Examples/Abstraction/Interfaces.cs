namespace CleanCodeLesson.Examples.Abstraction;

public interface ICustomerRepository
{
    Task<Customer> GetById(Guid id);
}