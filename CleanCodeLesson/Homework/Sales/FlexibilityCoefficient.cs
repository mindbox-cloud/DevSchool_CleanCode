namespace CleanCodeLesson.Homework.Sales;

public record FlexibilityCoefficient
{
    public double Value { get; }

    public FlexibilityCoefficient(double value)
    {
        if (value is < 0.01 or > 0.2)
            throw new ArgumentOutOfRangeException(nameof(value), "Flexibility coefficient must be between 0.01 and 0.2");

        Value = value;
    }
}