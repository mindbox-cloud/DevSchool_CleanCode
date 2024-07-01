using System.ComponentModel.DataAnnotations;

namespace CleanCodeLesson.Homework;

public record Length
{
    private int _lowerBoundCentimetreIncluded = 18;
    private int _upperBoundCentimetreIncluded = 50;
    public int Value { get; }

    public Length(int length)
    {
        if (length < _lowerBoundCentimetreIncluded || length > _upperBoundCentimetreIncluded)
        {
            throw new ValidationException(
                $"Length should be between {_lowerBoundCentimetreIncluded} and {_upperBoundCentimetreIncluded}");
        }

        Value = length;
    }
}

public record FlexabilityСoefficient
{
    private double _lowerBoundIncluded = 0.01;
    private double _upperBoundIncluded = 0.2;
    public double Value { get; }

    public FlexabilityСoefficient(double coefficient)
    {
        if (coefficient < _lowerBoundIncluded || coefficient > _upperBoundIncluded)
        {
            throw new ValidationException(
                $"Coefficient should be between {_lowerBoundIncluded} and {_upperBoundIncluded}");
        }

        Value = coefficient;
    }
}


public record MagicWand
{
    public Length Length { get; }
    public FlexabilityСoefficient FlexabilityСoefficient { get; }
}