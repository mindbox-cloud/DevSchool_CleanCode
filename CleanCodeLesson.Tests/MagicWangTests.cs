using CleanCodeLesson.Homework;
using FluentAssertions;

namespace CleanCodeLesson.Tests;

[TestClass]
public class MagicWandTests
{
    [DataTestMethod]
    [DynamicData(nameof(MagicWandTestData), DynamicDataSourceType.Method)]
    public void CalculatingPrice_ReturnsCorrectSum(int length, double coefficient, Wood wood, Core core,
        decimal expectedPrice)
    {
        //Arrange
        var lengthValue = new Length(length);
        var flexibilityValue = new FlexibilityСoefficient(coefficient);
        var wand = new MagicWand(lengthValue, flexibilityValue, wood, core);
        
        //Act
        var actualPrice = wand.CalculatePrice();
        
        //Assert
        actualPrice.Should().Be(expectedPrice);
    }
    
    public static IEnumerable<object[]> MagicWandTestData()
    {
        yield return [25, 0.1, Wood.Oak, Core.DragonHeartstring, 2.4m];
        yield return [30, 0.15, Wood.Taxus, Core.UnicornHorn, 1.8m];
        yield return [18, 0.05, Wood.Holy, Core.PhoenixFeather, 4.2m];
        yield return [50, 0.2, Wood.Cedrus, Core.DragonHeartstring, 2.3m];
    }
}