namespace CleanCodeLesson.Homework.Sales;

public record UnicornAge
{
    public int Value { get; }

    public UnicornAge(int value)
    {
        if (value is < 20 or > 300)
            throw new ArgumentOutOfRangeException(nameof(value), "Age must be between 20 and 300");
        
        Value = value;
    }
}