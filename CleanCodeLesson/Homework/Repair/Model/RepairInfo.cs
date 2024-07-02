namespace CleanCodeLesson.Homework.Repair;

public record RepairInfo(bool WasRepaired)
{
    public bool WasRepaired { get; private set; } = WasRepaired;

    public bool CanBeRepaired()
    {
        return !WasRepaired;
    }
    
    public RepairStatus MarkAsRepaired()
    {
        if (WasRepaired) return RepairStatus.DeclinedAsAlreadyRepaired;

        WasRepaired = true;
        return RepairStatus.Repaired;
    }
}