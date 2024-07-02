namespace CleanCodeLesson.Homework;

public abstract record Core(Price Price)
{
    public virtual Price Price { get; init; } = Price;
}