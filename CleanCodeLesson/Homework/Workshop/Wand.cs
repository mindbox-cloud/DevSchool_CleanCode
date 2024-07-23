namespace CleanCodeLesson.Homework.Workshop;

public record Wood(bool WasEverRepaired);
public record Core(bool WasEverRepaired);

public record Wand
{
    public Wood Wood { get; private set; }
    public Core Core { get; private set; }

    public Wand(Wood wood, Core core)
    {
        Wood = wood;
        Core = core;
    }

    public void SetCoreRepaired()
    {
        if (Core.WasEverRepaired)
        {
            throw new InvalidOperationException("Core was already repaired.");
        }
        Core = new (true);
    }

    public void SetWoodRepaired()
    {
        if (Wood.WasEverRepaired)
        {
            throw new InvalidOperationException("Wood was already repaired.");
        }
        Wood = new (true);
    }
}