using System.ComponentModel.DataAnnotations;

namespace CleanCodeLesson.Homework;

public record Price
{
    public Price(decimal value)
    {
        Value = value;
        if (Value < 0)
            throw new ValidationException("Price cannot be negative");
    }

    public decimal Value { get; }
    
    public static Price operator +(Price first, Price second) => new (first.Value + second.Value);
    public static Price operator *(Price first, decimal second) => new (first.Value * second);
}