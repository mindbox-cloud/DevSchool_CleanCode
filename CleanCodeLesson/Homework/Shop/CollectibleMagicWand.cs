using System.ComponentModel.DataAnnotations;
using CleanCodeLesson.Homework.Shop.Cores;
using CleanCodeLesson.Homework.Shop.ValueTypes;

namespace CleanCodeLesson.Homework.Shop;

public record CollectibleMagicWand(
    Length Length,
    Flexibility Flexibility,
    Wood Wood,
    ICore? Core,
    Price Price) : IMagicWand
{
    private List<Wizard> owners = [];

    public IReadOnlyCollection<Wizard> GetOwners() => owners;

    public void AddOwner(Wizard wizard)
    {
        if (!wizard.Age.Adult)
        {
            throw new ValidationException("Wizard is too young.");
        }
        
        owners.Add(wizard);
    }
}