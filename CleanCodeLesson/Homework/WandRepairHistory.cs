namespace CleanCodeLesson.Homework;

public record WandRepairHistory
{
    public required bool isCoreWasRepaired { get; init; }
    public required bool isWoodWasRepaired { get; init; }
};