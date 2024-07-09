using CleanCodeLesson.Homework.Cores;
using CleanCodeLesson.Homework.ValueTypes;

namespace CleanCodeLesson.Homework;

public record MagicWand(
    Length Length, 
    Flexibility Flexibility, 
    Wood Wood, 
    ICore Core)
{
    public Price CalculatePrice => Wood.Price + Core.Price;
}