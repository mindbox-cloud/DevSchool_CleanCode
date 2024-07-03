namespace CleanCodeLesson.Homework.Cores;

public record PhoenixFeatherCore : ICore
{
    public Price Price { get; } = new(4m);
}