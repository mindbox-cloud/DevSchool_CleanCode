using System.ComponentModel.DataAnnotations;

namespace CleanCodeLesson.Homework;

public record Price
{
    public double Value { get; init; }

    public Price(double value)
    {
        if (value < 0)
        {
            throw new ValidationException("Price cant be less than 0.");
        }

        Value = value;
    }
}