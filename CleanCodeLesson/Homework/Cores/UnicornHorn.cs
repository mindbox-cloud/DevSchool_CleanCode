using CleanCodeLesson.Homework.ValueTypes;

namespace CleanCodeLesson.Homework.Cores;

public record UnicornHorn : ICore
{
    public Age Age { get; }
    private readonly Price _basePrice = new (Constants.CorePrice.UnicornHorn);

    protected UnicornHorn(Age age)
    {
        Age = age;
    }

    public Price Price => Age.Value > 100 ? _basePrice * (Age.Value / 100m) : _basePrice;
}