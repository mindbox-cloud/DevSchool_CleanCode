namespace CleanCodeLesson.Homework;

public record DragonHeartstring : ICore
{
    private readonly IDragonHeartstringType _dragonHeartstringType;

    public DragonHeartstring(IDragonHeartstringType dragonHeartstringType)
    {
        _dragonHeartstringType = dragonHeartstringType;
    }
    
    public decimal CalculatePrice() => 2m * _dragonHeartstringType.PriceMultiplier;
}