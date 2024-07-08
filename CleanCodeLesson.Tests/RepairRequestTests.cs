using CleanCodeLesson.Homework;

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
    
    
    public static IEnumerable<object[]> RepairRequestTestData()
    {
        yield return
        [
            new RepairRequest
            {
                IsCoreBroken = true,
                IsWoodBroken = false,
                WandRepairHistory = new WandRepairHistory { isCoreWasRepaired = true, isWoodWasRepaired = false }
            },
            false
        ];

        yield return
        [
            new RepairRequest
            {
                IsCoreBroken = false,
                IsWoodBroken = true,
                WandRepairHistory = new WandRepairHistory { isCoreWasRepaired = false, isWoodWasRepaired = true }
            },
            false
        ];

        yield return
        [
            new RepairRequest
            {
                IsCoreBroken = true,
                IsWoodBroken = true,
                WandRepairHistory = new WandRepairHistory { isCoreWasRepaired = true, isWoodWasRepaired = true }
            },
            false
        ];

        yield return
        [
            new RepairRequest
            {
                IsCoreBroken = true,
                IsWoodBroken = false,
                WandRepairHistory = new WandRepairHistory { isCoreWasRepaired = false, isWoodWasRepaired = false }
            },
            true
        ];

        yield return
        [
            new RepairRequest
            {
                IsCoreBroken = false,
                IsWoodBroken = true,
                WandRepairHistory = new WandRepairHistory { isCoreWasRepaired = false, isWoodWasRepaired = false }
            },
            true
        ];

        yield return
        [
            new RepairRequest
            {
                IsCoreBroken = false,
                IsWoodBroken = false,
                WandRepairHistory = new WandRepairHistory { isCoreWasRepaired = true, isWoodWasRepaired = true }
            },
            true
        ];
    }
}