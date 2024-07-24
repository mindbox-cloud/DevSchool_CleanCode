using System.ComponentModel.DataAnnotations;

namespace CleanCodeLesson.Homework.Shop.ValueTypes;

public record Name
{
    public string Value { get; init; }

    public Name(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ValidationException("Name is incorrect");

        Value = value;
    }
}