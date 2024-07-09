using System.ComponentModel.DataAnnotations;

namespace CleanCodeLesson.Homework.ValueTypes;

public record Price
{
    public decimal Value { get; init; }

    public Price(decimal value)
    {
        if (value < 0)
        {
            throw new ValidationException("Price cant be less than 0.");
        }

        Value = value;
    }
    
    public static Price operator +(Price price1, Price price2)
    {
        return new Price(price1.Value + price2.Value);
    }
    
    public static Price operator *(Price price1, decimal value)
    {
        return new Price(price1.Value * value);
    }
}