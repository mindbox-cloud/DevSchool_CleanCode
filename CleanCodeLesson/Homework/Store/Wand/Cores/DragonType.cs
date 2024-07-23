namespace CleanCodeLesson.Homework.Cores;

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