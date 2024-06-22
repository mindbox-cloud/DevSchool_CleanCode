namespace CleanCodeLesson.Abstraction;

//Задача: тарифы и услуги

//1. Нужно иметь продуктовые планы, где будут наборы услуг с ежедневной тарификацией тарификацией
//2. Нужно уметь считать стоимость тарифа за период обслуживания

public class ProductPlan
{
    public string Name { get; }

    public List<Service> Services { get; private set; }

    public decimal CalculateForPeriod(DateTime from, DateTime to)
    {
        var days = (to - from).Days;
        var sum = Services.Sum(z => z.DailyCost) * days;

        return sum;
    }
}

public class Service
{
    public string Name { get; private set; }

    public decimal DailyCost { get; private set; }
}