namespace CleanCodeLesson.Homework;

public record DragonHeartstring(DragonType DragonType) : Core(new Price(2m))
{
    public override Price Price => 2m * DragonType.PriceMultiplier;
}