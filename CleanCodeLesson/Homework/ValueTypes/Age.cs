using System.ComponentModel.DataAnnotations;

namespace CleanCodeLesson.Homework.ValueTypes;

public record Age
{
    public int Value { get; }

    public Age(int value)
    {
        if (value is < 20 or > 300)
            throw new ValidationException("Age is incorrect");

        Value = value;
    }
}