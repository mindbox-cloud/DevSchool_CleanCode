using System.Collections.ObjectModel;
using CleanCodeLesson.Homework.Cores;

namespace CleanCodeLesson.Homework;

public record CollectibleWand(
    Length length,
    FlexibilityСoefficient flexibilityСoefficient,
    Wood wood,
    ICore? core,
    Price price)
    : IMagicWand
{
    private List<WandOwner> owners;
    public IReadOnlyCollection<WandOwner> Owners => owners;
    
    public Length Length { get; } = length;
    public FlexibilityСoefficient FlexibilityСoefficient { get; } = flexibilityСoefficient;
    public Wood Wood { get; } = wood;

    public ICore? Core { get; } = core;

    public Price Price { get; } = price;

    public Price CalculatePrice() => Price;

    public bool TrySell(WandOwner owner)
    {
        if (CanBeSold(owner))
        {
            owners.Add(owner);
            return true;
        }

        return false;
    }

    private bool CanBeSold(WandOwner owner)
    {
        return owner.Age >= 18;
    }
}