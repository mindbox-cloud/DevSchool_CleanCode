namespace CleanCodeLesson.Homework.Cores;

public record UnicornHornCore : ICore
{
    public UnicornHornCore(UnicornAge unicornAge)
    {
        Price = new Price(1.6m);

        if (unicornAge.Value > 100)
        {
            Price *= (unicornAge.Value / 100m);
        }
    }
    
    public Price Price { get; }
}