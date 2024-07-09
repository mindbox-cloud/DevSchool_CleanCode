using CleanCodeLesson.Homework.ValueTypes;

namespace CleanCodeLesson.Homework.Cores;

public record PhoenixFeather : ICore
{
    public Price Price => new (Constants.CorePrice.PhoenixFeather);
}