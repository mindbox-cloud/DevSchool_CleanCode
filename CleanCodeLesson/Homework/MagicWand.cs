namespace CleanCodeLesson.Homework;

public class MagicWand
{
    public Length Length { get; init; }
    public FlexibilityCoefficient FlexibilityCoefficient { get; init; }
    public IWood Wood { get; init; }
    public ICore Core { get; init; }

    public MagicWand(Length length, FlexibilityCoefficient coefficient, IWood wood, ICore core)
    {
        Length = length;
        FlexibilityCoefficient = coefficient;
        Wood = wood;
        Core = core;
    }
}