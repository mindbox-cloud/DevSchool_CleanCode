using CleanCodeLesson.Homework.Cores;

namespace CleanCodeLesson.Homework;

public record CollectibleWand(
    Length length,
    FlexibilityСoefficient flexibilityСoefficient,
    Wood wood,
    ICore? core,
    Price price,
    IReadOnlyCollection<WandOwner> owners)
    : IMagicWand
{

    public Length Length { get; } = length;
    public FlexibilityСoefficient FlexibilityСoefficient { get; } = flexibilityСoefficient;
    public Wood Wood { get; } = wood;

    public ICore? Core { get; } = core;

    public Price Price { get; } = price;

    public IReadOnlyCollection<WandOwner> Owners { get; } = owners;

    public Price CalculatePrice() => Price;
}