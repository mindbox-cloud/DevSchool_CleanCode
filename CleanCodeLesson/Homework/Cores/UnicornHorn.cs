namespace CleanCodeLesson.Homework;

public record UnicornHorn : ICore
{
    private readonly decimal _basePrice = 1.6m;
    
    public Age Age { get; set; }
    
    public UnicornHorn(Age age)
    {
        Age = age;
    }

    public decimal CalculatePrice()
    {
        if (Age.Value > 100)
        {
            return (Age.Value / 100m) * _basePrice;
        }

        return _basePrice;
    }
}