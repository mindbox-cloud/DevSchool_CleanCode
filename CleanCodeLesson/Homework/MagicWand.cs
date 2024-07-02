namespace CleanCodeLesson.Homework;

public class MagicWand
{
    public Length Length { get; init; }
    public FlexibilityCoefficient FlexibilityCoefficient { get; init; }
    public Wood Wood { get; init; }
    public Core Core { get; init; }

    public MagicWand(Length length, FlexibilityCoefficient coefficient, Wood wood, Core core)
    {
        Length = length;
        FlexibilityCoefficient = coefficient;
        Wood = wood;
        Core = core;
    }

    public Price CalculatePrice()
    {
        return Wood.Price + Core.Price;
    }
}