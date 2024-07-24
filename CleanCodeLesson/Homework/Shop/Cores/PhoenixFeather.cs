using CleanCodeLesson.Homework.Shop.ValueTypes;

namespace CleanCodeLesson.Homework.Shop.Cores;

public record PhoenixFeather : ICore
{
    public Price Price => new (Constants.CorePrice.PhoenixFeather);
}