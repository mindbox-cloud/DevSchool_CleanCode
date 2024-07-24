using System.ComponentModel.DataAnnotations;

namespace CleanCodeLesson.Homework.Shop.ValueTypes;

public record Length
{
    public double Value { get; init; }

    public Length(double value)
    {
        if (value is < 18 or > 50)
            throw new ValidationException("Length is incorrect");

        Value = value;
    }
};