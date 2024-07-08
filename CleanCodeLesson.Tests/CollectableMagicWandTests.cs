using CleanCodeLesson.Homework;
using FluentAssertions;

namespace CleanCodeLesson.Tests;

[TestClass]
public class CollectableMagicWandTests
{
    [TestMethod]
    public void CalculatingPrice_ReturnsCorrectSum()
    {
        //Arrange
        var lengthValue = new Length(30);
        var flexibilityValue = new FlexibilityСoefficient(0.15);
        var wood = Wood.Cedrus;
        var price = new Price(100000);
        var ownersHistory = new List<WandOwner>();

        var wand = new CollectibleWand(lengthValue, flexibilityValue, wood, default, price, ownersHistory);

        //Act
        var actualPrice = wand.CalculatePrice();

        //Assert
        actualPrice.Should().Be(price);
    }

    [TestMethod]
    public void TrySell_WhenOwnerIsAdult_Sold()
    {
        //Arrange
        var lengthValue = new Length(30);
        var flexibilityValue = new FlexibilityСoefficient(0.15);
        var wood = Wood.Cedrus;
        var price = new Price(100000);
        
        var ownersHistory = new List<WandOwner>();
        var owner = new WandOwner("Ryan Gosling", 43);

        var wand = new CollectibleWand(lengthValue, flexibilityValue, wood, default, price, ownersHistory);

        //Act
        var isSold = wand.TrySell(owner);

        //Assert
        isSold.Should().BeTrue();
    }

    [TestMethod]
    public void TrySell_WhenOwnerIsNotAdult_NotSold()
    {
        //Arrange
        var lengthValue = new Length(30);
        var flexibilityValue = new FlexibilityСoefficient(0.15);
        var wood = Wood.Cedrus;
        var price = new Price(100000);

        var ownersHistory = new List<WandOwner>();
        var owner = new WandOwner("Emma Watson", 12);

        var wand = new CollectibleWand(lengthValue, flexibilityValue, wood, default, price, ownersHistory);

        //Act
        var isSold = wand.TrySell(owner);

        //Assert
        isSold.Should().BeFalse();
    }
}