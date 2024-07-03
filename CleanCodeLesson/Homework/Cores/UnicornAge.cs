using System.ComponentModel.DataAnnotations;

namespace CleanCodeLesson.Homework.Cores;

public record UnicornAge
{
    private const int _lowerBoundIncluded = 20;
    private const int _upperBoundIncluded = 300;
    
    public UnicornAge(int value)
    {
        Value = value;
        if (Value < _lowerBoundIncluded && Value > _upperBoundIncluded)
        {
            throw new ValidationException(
                $"Age should be between {_lowerBoundIncluded} and {_upperBoundIncluded}");
        }
    }

    public int Value { get; }
}