namespace CleanCodeLesson.Homework;

public record Length
{
    public int Value { get; }

    public Length(int value)
    {
        if (value is < 18 or > 50)
            throw new ArgumentOutOfRangeException(nameof(value), "Length must be between 18 and 50");

        Value = value;
    }
}