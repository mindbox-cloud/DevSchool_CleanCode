namespace CleanCodeLesson.Homework.Cores;

public record DragonHeartstringCore : ICore
{
    public DragonHeartstringCore(DragonType dragonType)
    {
        var basePrice = new Price(2m);
        Price = basePrice * dragonType.PriceModifier;
    }
    
    public Price Price { get; } = new(2m);
}