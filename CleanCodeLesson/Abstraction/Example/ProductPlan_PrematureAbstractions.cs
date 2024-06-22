namespace CleanCodeLesson.Abstraction;

//Задача: тарифы и услуги

//1. Нужно иметь продуктовые планы, где будут наборы услуг с ежедневной тарификацией тарификацией
//2. Нужно уметь считать стоимость тарифа за период обслуживания

public class ProductPlan
{
    public string Name { get; }

    public List<Service> Services { get; private set; }

    public decimal CalculateForPeriod(DateTime from, DateTime to) => Services.Sum(z => z.CalculateForPeriod(from, to));
}

public class Service
{
    public string Name { get; private set; }

    public decimal DailyCost { get; private set; }

    public decimal CalculateForPeriod(DateTime from, DateTime to) => (to - from).Days * DailyCost;
}