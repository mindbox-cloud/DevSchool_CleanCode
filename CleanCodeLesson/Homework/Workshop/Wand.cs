namespace CleanCodeLesson.Homework.Workshop;

public record Wand
{
    public bool IsCoreWasRepaired { get; private set; }
    public bool IsWoodWasRepaired { get; private set; }

    public Wand(bool isCoreWasRepaired, bool isWoodWasRepaired)
    {
        IsCoreWasRepaired = isCoreWasRepaired;
        IsWoodWasRepaired = isWoodWasRepaired;
    }

    public void SetCoreRepaired()
    {
        if (IsCoreWasRepaired)
        {
            throw new InvalidOperationException("Core was already repaired.");
        }
        IsCoreWasRepaired = true;
    }

    public void SetWoodRepaired()
    {
        if (IsWoodWasRepaired)
        {
            throw new InvalidOperationException("Wood was already repaired.");
        }
        IsWoodWasRepaired = true;
    }
}