using System.ComponentModel.DataAnnotations;

namespace CleanCodeLesson.Homework;

public record FlexibilityСoefficient
{
    private const double _lowerBoundIncluded = 0.01;
    private const double _upperBoundIncluded = 0.2;
    public double Value { get; }

    public FlexibilityСoefficient(double coefficient)
    {
        if (coefficient is < _lowerBoundIncluded or > _upperBoundIncluded)
        {
            throw new ValidationException(
                $"Coefficient should be between {_lowerBoundIncluded} and {_upperBoundIncluded}");
        }

        Value = coefficient;
    }
}