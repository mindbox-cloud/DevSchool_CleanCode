namespace CleanCodeLesson.Homework;

public record CustomerAge
{
    public int Value { get; init; }
    
    public CustomerAge(int age)
    {
        if (age < 0) throw new ArgumentException("Age must be positive");
        Value = age;
    }
}

public record Customer(CustomerAge Age, string FirstName, string LastName)
{
    public bool IsAdult => Age.Value > 18;
}