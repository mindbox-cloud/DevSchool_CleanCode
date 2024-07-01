namespace CleanCodeLesson.Homework;

public record Age
{
    public int Value { get; set; }

    public Age(int value)
    {
        if (value is < 20 or > 300) throw new ArgumentException("Age must be between 20 and 300");
        
        Value = value;
    }
}