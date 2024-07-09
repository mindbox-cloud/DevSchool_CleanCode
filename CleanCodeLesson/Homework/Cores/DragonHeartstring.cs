using CleanCodeLesson.Homework.ValueTypes;

namespace CleanCodeLesson.Homework.Cores;

public record DragonHeartstring : ICore
{
    public DragonHeartstringType Type { get; set; }
    private readonly Price _basePrice = new (Constants.CorePrice.DragonHeartstring);

    private DragonHeartstring(DragonHeartstringType type)
    {
        Type = type;
    }

    public Price Price => _basePrice * Type.Coefficient;
}