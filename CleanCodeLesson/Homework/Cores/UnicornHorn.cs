using CleanCodeLesson.Homework.ValueTypes;

namespace CleanCodeLesson.Homework.Cores;

public record UnicornHorn : ICore
{
    public UnicornAge UnicornAge { get; }
    private readonly Price _basePrice = new (Constants.CorePrice.UnicornHorn);

    protected UnicornHorn(UnicornAge unicornAge)
    {
        UnicornAge = unicornAge;
    }

    public Price Price => UnicornAge.Value > 100 ? _basePrice * (UnicornAge.Value / 100m) : _basePrice;
}