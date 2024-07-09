using System.ComponentModel.DataAnnotations;

namespace CleanCodeLesson.Homework;

public record Flexibility
{
    public double Value { get; init; }

    public Flexibility(double value)
    {
        if (value is < 0.01 or > 0.2)
            throw new ValidationException("Length is incorrect");

        Value = value;
    }
};