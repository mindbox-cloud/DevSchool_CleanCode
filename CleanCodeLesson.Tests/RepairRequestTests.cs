using CleanCodeLesson.Homework.Workshop;

namespace CleanCodeLesson.Tests;

[TestClass]
public class RepairRequestTests
{

    [DataTestMethod]
    [DynamicData(nameof(RepairRequestTestData), DynamicDataSourceType.Method)]
    public void CouldBeRepaired_TestCases(RepairRequest request, bool expectedResult)
    {
        // Act
        bool result = request.CouldBeRepaired();

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [DataTestMethod]
    public void CouldBeRepaired_WhenBothPartsNotBroken_ThrowsException()
    {
        // Act
        var act = () => new RepairRequest(
            new Wand(isCoreWasRepaired: false, isWoodWasRepaired: false),
            isCoreBroken: false,
            isWoodBroken: false
        );

        // Assert
        Assert.ThrowsException<ArgumentException>(act);
    }
    
    
    public static IEnumerable<object[]> RepairRequestTestData()
    {
        yield return new object[]
        {
            new RepairRequest(
                new Wand(isCoreWasRepaired: true, isWoodWasRepaired: false),
                isCoreBroken: true,
                isWoodBroken: false
            ),
            false
        };

        yield return new object[]
        {
            new RepairRequest(
                new Wand(isCoreWasRepaired: false, isWoodWasRepaired: true),
                isCoreBroken: false,
                isWoodBroken: true
            ),
            false
        };

        yield return new object[]
        {
            new RepairRequest(
                new Wand(isCoreWasRepaired: true, isWoodWasRepaired: true),
                isCoreBroken: true,
                isWoodBroken: true
            ),
            false
        };

        yield return new object[]
        {
            new RepairRequest(
                new Wand(isCoreWasRepaired: false, isWoodWasRepaired: false),
                isCoreBroken: true,
                isWoodBroken: false
            ),
            true
        };

        yield return new object[]
        {
            new RepairRequest(
                new Wand(isCoreWasRepaired: false, isWoodWasRepaired: false),
                isCoreBroken: false,
                isWoodBroken: true
            ),
            true
        };
    }
}
