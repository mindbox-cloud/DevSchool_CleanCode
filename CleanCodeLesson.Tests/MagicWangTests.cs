using CleanCodeLesson.Homework;
using CleanCodeLesson.Homework.Cores;
using FluentAssertions;

namespace CleanCodeLesson.Tests;

[TestClass]
public class MagicWandTests
{
    [DataTestMethod]
    [DynamicData(nameof(MagicWandTestData), DynamicDataSourceType.Method)]
    public void CalculatingPrice_ReturnsCorrectSum(int length, double coefficient, Wood wood, ICore core,
        decimal expectedPrice)
    {
        //Arrange
        var lengthValue = new Length(length);
        var flexibilityValue = new FlexibilityСoefficient(coefficient);
        var wand = new MagicWand(lengthValue, flexibilityValue, wood, core);
        
        //Act
        var actualPrice = wand.CalculatePrice();
        
        //Assert
        actualPrice.Value.Should().Be(expectedPrice);
    }
    
    public static IEnumerable<object[]> MagicWandTestData()
    {
        yield return [30, 0.15, Wood.Taxus, new UnicornHornCore(new UnicornAge(20)), 1.8m];
        yield return [30, 0.15, Wood.Taxus, new UnicornHornCore(new UnicornAge(200)), 3.4m];
        yield return [18, 0.05, Wood.Holy, new PhoenixFeatherCore(), 4.2m];
        yield return [50, 0.2, Wood.Cedrus, new DragonHeartstringCore(DragonType.ChineseFireball), 3.2m];
        yield return [25, 0.1, Wood.Oak, new DragonHeartstringCore(DragonType.RomaniamLonghorn), 2.4m];
    }
}