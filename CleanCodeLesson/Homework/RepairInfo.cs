namespace CleanCodeLesson.Homework;

public record RepairInfo
{
    private bool _repaired;
    public bool Repaired => _repaired;
    public void Repair() => _repaired = true;
}