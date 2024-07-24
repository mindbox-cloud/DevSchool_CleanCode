using System.ComponentModel.DataAnnotations;

namespace CleanCodeLesson.Homework.Repair;

public record RepairRequest
{
    public MagicWand MagicWand { get; init; }
    
    public bool CoreBroken { get; init; }
    
    public bool WoodBroken { get; init; }
    
    public RepairRequest(MagicWand magicWand, bool coreBroken, bool woodBroken)
    {
        if (coreBroken && magicWand.CoreRepairInfo.Repaired)
            throw new ValidationException("Core already repaired.");
        
        if (woodBroken && magicWand.WoodRepairInfo.Repaired)
            throw new ValidationException("Wood already repaired.");

        MagicWand = magicWand;
        CoreBroken = coreBroken;
        WoodBroken = woodBroken;
    }
}

