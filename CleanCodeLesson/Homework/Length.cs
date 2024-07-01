namespace CleanCodeLesson.Homework;

public record Length
{
    public int Value { get; init; }
    public Length(int value)
    {
        if (value is < 18 or > 50) throw new ArgumentException("Length must be between 18 and 50");
        Value = value;
    }
}