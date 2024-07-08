namespace CleanCodeLesson.Homework;

public record RepairRequest
{
    public required WandRepairHistory WandRepairHistory { get; init; }
    public required bool IsCoreBroken { get; init; }
    public required bool IsWoodBroken { get; init; }

    public bool CouldBeRepaired()
    {
        if (IsCoreBroken && WandRepairHistory.isCoreWasRepaired)
        {
            return false;
        }

        if (IsWoodBroken && WandRepairHistory.isWoodWasRepaired)
        {
            return false;
        }

        return true;
    }
}
