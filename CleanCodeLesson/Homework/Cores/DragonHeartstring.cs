namespace CleanCodeLesson.Homework;

public record DragonHeartstring(IDragonHeartstringType DragonHeartstringType) : Core(new Price(2m))
{
    public decimal CalculatePrice() => 2m * DragonHeartstringType.PriceMultiplier;
}