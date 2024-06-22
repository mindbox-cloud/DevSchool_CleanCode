namespace CleanCodeLesson.Abstraction.Example;

public interface ICustomerRepository
{
    Task<Customer> GetById(Guid id);
}