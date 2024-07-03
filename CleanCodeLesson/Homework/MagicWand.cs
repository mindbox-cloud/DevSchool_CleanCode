using CleanCodeLesson.Homework.Cores;

namespace CleanCodeLesson.Homework;

public record MagicWand : IMagicWand
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