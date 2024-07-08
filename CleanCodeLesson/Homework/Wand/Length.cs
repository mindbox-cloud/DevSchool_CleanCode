using System.ComponentModel.DataAnnotations;

namespace CleanCodeLesson.Homework;

public record Length
{
    private const int _lowerBoundCentimetreIncluded = 18;
    private const int _upperBoundCentimetreIncluded = 50;
    public int Value { get; }

    public Length(int length)
    {
        if (length is < _lowerBoundCentimetreIncluded or > _upperBoundCentimetreIncluded)
        {
            throw new ValidationException(
                $"Length should be between {_lowerBoundCentimetreIncluded} and {_upperBoundCentimetreIncluded}");
        }

        Value = length;
    }
}