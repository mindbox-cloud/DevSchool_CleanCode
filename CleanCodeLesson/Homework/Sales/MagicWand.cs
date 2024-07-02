namespace CleanCodeLesson.Homework.Sales;

public abstract record MagicWand(Length Length, FlexibilityCoefficient Coefficient, Wood Wood)
{
    public abstract Price Price { get; }
}

public record RegularMagicWand : MagicWand
{
    public Core Core { get; init; }
    public override Price Price { get; }

    public RegularMagicWand(Length length, FlexibilityCoefficient coefficient, Wood wood, Core core) 
        : base(length, coefficient, wood)
    {
        Core = core;
        Price = CalculatePrice();
    }

    private Price CalculatePrice()
    {
        return Wood.Price + Core.Price;
    }
}

public record Owner(string FirstName, string LastName);

public record OwnersHistory(List<Owner> Owners);

public record CollectibleMagicWand : MagicWand
{
    public Core? Core { get; init; }
    public OwnersHistory OwnersHistory { get; init; }
    public override Price Price { get;}

    public CollectibleMagicWand(Length length, FlexibilityCoefficient coefficient, Wood wood, Core? core, OwnersHistory history, Price price) 
        : base(length, coefficient, wood)
    {
        Core = core;
        OwnersHistory = history;
        Price = price;
    }
}