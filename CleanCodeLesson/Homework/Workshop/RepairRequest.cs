namespace CleanCodeLesson.Homework.Workshop;

public record RepairRequest
{
    public Wand Wand { get; }
    public bool IsCoreBroken { get; }
    public bool IsWoodBroken { get; }

    public RepairRequest(Wand wand, bool isCoreBroken, bool isWoodBroken)
    {
        if (!isCoreBroken && !isWoodBroken)
        {
            throw new ArgumentException("Invalid repair request. Both core and wood are not broken.");
        }

        Wand = wand;
        IsCoreBroken = isCoreBroken;
        IsWoodBroken = isWoodBroken;
    }

    public bool CouldBeRepaired()
    {
        if (IsCoreBroken && Wand.Core.WasEverRepaired)
        {
            return false;
        }

        if (IsWoodBroken && Wand.Wood.WasEverRepaired)
        {
            return false;
        }

        return true;
    }

    public void Repair()
    {
        if (!CouldBeRepaired())
        {
            throw new InvalidOperationException("Wand could not be repaired.");
        }

        if (IsCoreBroken)
        {
            Wand.SetCoreRepaired();
        }

        if (IsWoodBroken)
        {
            Wand.SetWoodRepaired();
        }
    }
}
