using System.ComponentModel.DataAnnotations;

namespace CleanCodeLesson.Homework.Shop.ValueTypes;

public record UnicornAge
{
    public int Value { get; }

    public UnicornAge(int value)
    {
        if (value is < 20 or > 300)
            throw new ValidationException("Age is incorrect");

        Value = value;
    }
}