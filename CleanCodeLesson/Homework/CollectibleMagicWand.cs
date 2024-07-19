using System.ComponentModel.DataAnnotations;
using CleanCodeLesson.Homework.Cores;
using CleanCodeLesson.Homework.ValueTypes;

namespace CleanCodeLesson.Homework;

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