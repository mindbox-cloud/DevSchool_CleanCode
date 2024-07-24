using System.ComponentModel.DataAnnotations;

namespace CleanCodeLesson.Homework.Shop.ValueTypes;

public record Age
{
    public int Value { get; init; }

    public bool Adult => Value >= 18;

    public Age(int value)
    {
        if (value is < 1)
            throw new ValidationException("Age is incorrect");

        Value = value;
    }
}