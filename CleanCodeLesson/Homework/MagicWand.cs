using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace CleanCodeLesson.Homework;

public record Length
{
    private const int _lowerBoundCentimetreIncluded = 18;
    private const int _upperBoundCentimetreIncluded = 50;
    public int Value { get; }

    public Length(int length)
    {
        if (length is < _lowerBoundCentimetreIncluded or > _upperBoundCentimetreIncluded)
        {
            throw new ValidationException(
                $"Length should be between {_lowerBoundCentimetreIncluded} and {_upperBoundCentimetreIncluded}");
        }

        Value = length;
    }
}

public record FlexibilityСoefficient
{
    private const double _lowerBoundIncluded = 0.01;
    private const double _upperBoundIncluded = 0.2;
    public double Value { get; }

    public FlexibilityСoefficient(double coefficient)
    {
        if (coefficient is < _lowerBoundIncluded or > _upperBoundIncluded)
        {
            throw new ValidationException(
                $"Coefficient should be between {_lowerBoundIncluded} and {_upperBoundIncluded}");
        }

        Value = coefficient;
    }
}

public record Price
{
    public Price(decimal value)
    {
        Value = value;
        if (Value < 0)
            throw new ValidationException("Price cannot be negative");
    }

    public decimal Value { get; }
    
    public static Price operator +(Price first, Price second) => new (first.Value + second.Value);
    public static Price operator *(Price first, decimal second) => new (first.Value * second);
}

public record Wood
{
    public static Wood Taxus => new(new Price(0.2m)); // Тис
    public static Wood Holy => new(new Price(0.2m)); // Остролист
    public static Wood Cedrus => new(new Price(0.3m)); // Кедр
    public static Wood Oak => new(new Price(0.4m)); // Дуб

    private Wood(Price price)
    {
        Price = price;
    }

    public Price Price { get; }
}

public record UnicornAge
{
    private const int _lowerBoundIncluded = 20;
    private const int _upperBoundIncluded = 300;
    
    public UnicornAge(int value)
    {
        Value = value;
        if (Value < _lowerBoundIncluded && Value > _upperBoundIncluded)
        {
            throw new ValidationException(
                $"Age should be between {_lowerBoundIncluded} and {_upperBoundIncluded}");
        }
    }

    public int Value { get; }
}

public interface ICore
{
    public Price Price { get; }
}

public record DragonType
{
    public static DragonType HungarianHorntail => new DragonType(2.25m);
    public static DragonType ChineseFireball => new DragonType(1.45m);
    public static DragonType RomaniamLonghorn => new DragonType(1m);
    public static DragonType NorwegianRidgeback => new DragonType(0.92m);
    
    private DragonType(decimal priceModifier)
    {
        PriceModifier = priceModifier;
    }

    public decimal PriceModifier { get; }
}

public record DragonHeartstringCore : ICore
{
    public DragonHeartstringCore(DragonType dragonType)
    {
        var basePrice = new Price(2m);
        Price = basePrice * dragonType.PriceModifier;
    }
    
    public Price Price { get; } = new(2m);
}

public record PhoenixFeatherCore : ICore
{
    public Price Price { get; } = new(4m);
}

public record UnicornHornCore : ICore
{
    public UnicornHornCore(UnicornAge unicornAge)
    {
        Price = new Price(1.6m);

        if (unicornAge.Value > 100)
        {
            Price *= (unicornAge.Value / 100m);
        }
    }
    
    public Price Price { get; }
}
    


public record MagicWand
{
    public MagicWand(Length length, FlexibilityСoefficient flexibilityСoefficient, Wood wood, ICore core)
    {
        Length = length;
        FlexibilityСoefficient = flexibilityСoefficient;
        Wood = wood;
        Core = core;
    }

    public Length Length { get; }
    public FlexibilityСoefficient FlexibilityСoefficient { get; }
    public Wood Wood { get; }
    
    public ICore Core { get; }

    public Price CalculatePrice()
    {
        return Wood.Price + Core.Price;
    }
}