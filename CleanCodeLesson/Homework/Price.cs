namespace CleanCodeLesson.Homework;

public record Price(decimal Value)
{
    public static Price operator +(Price a, Price b)
    {
        return new Price(a.Value + b.Value);
    }
}