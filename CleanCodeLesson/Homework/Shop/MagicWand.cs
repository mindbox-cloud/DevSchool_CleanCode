using CleanCodeLesson.Homework.Shop.Cores;
using CleanCodeLesson.Homework.Shop.ValueTypes;

namespace CleanCodeLesson.Homework.Shop;

public record MagicWand(
    Length Length, 
    Flexibility Flexibility, 
    Wood Wood, 
    ICore Core) : IMagicWand
{
    public Price Price => Wood.Price + Core.Price;
}