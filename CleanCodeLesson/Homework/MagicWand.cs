namespace CleanCodeLesson.Homework;

public record MagicWand(
    Length Length, 
    Flexibility Flexibility, 
    Wood Wood, 
    Core Core)
{
    public Price CalculatePrice => Wood.Price + Core.Price;
}