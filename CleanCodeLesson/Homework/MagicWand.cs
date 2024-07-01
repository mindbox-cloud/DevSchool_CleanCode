﻿using System.ComponentModel.DataAnnotations;

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

public record Price
{
    public Price(decimal value)
    {
        Value = value;
        if (Value < 0)
            throw new ValidationException("Price cannot be negative");
    }

    public decimal Value { get; }
}

public record Wood
{
    public static Wood Taxus => new(0.2m); // Тис
    public static Wood Holy => new(0.2m); // Остролист
    public static Wood Cedrus => new(0.3m); // Кедр
    public static Wood Oak => new(0.4m); // Дуб

    private Wood(decimal price)
    {
        Price = new Price(price);
    }

    public Price Price { get; }
}

public record Core
{
    public static Core DragonHeartstring => new Core(2m);
    public static Core UnicornHorn => new Core(1.6m);
    public static Core PhoenixFeather => new Core(4m);

    private Core(decimal price)
    {
        Price = new Price(price);
    }

    public Price Price { get; }
}

public record MagicWand
{
    public MagicWand(Length length, FlexibilityСoefficient flexibilityСoefficient, Wood wood, Core core)
    {
        Length = length;
        FlexibilityСoefficient = flexibilityСoefficient;
        Wood = wood;
        Core = core;
    }

    public Length Length { get; }
    public FlexibilityСoefficient FlexibilityСoefficient { get; }
    public Wood Wood { get; }
    public Core Core { get; }

    public decimal CalculatePrice()
    {
        return Wood.Price.Value + Core.Price.Value;
    }
}