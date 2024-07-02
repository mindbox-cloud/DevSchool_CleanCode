namespace CleanCodeLesson.Homework.Sales;

public record Price(decimal Value)
{
    public static Price operator +(Price a, Price b) => new(a.Value + b.Value);

    public static Price operator *(decimal a, Price b) => new(a * b.Value);
    public static Price operator *(Price a, decimal b) => new(a.Value * b);

    public static implicit operator Price(decimal value) => new Price(value);
}