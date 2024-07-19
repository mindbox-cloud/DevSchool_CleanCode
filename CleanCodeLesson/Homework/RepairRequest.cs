using System.ComponentModel.DataAnnotations;

namespace CleanCodeLesson.Homework;

public record RepairRequest
{
    public MagicWandRepairInfo MagicWandRepairInfo { get; init; }
    
    public bool CoreBroken { get; init; }
    
    public bool WoodBroken { get; init; }
    
    public RepairRequest(MagicWandRepairInfo magicWandRepairInfo, bool coreBroken, bool woodBroken)
    {
        if (coreBroken && magicWandRepairInfo.CoreRepairInfo.Repaired)
            throw new ValidationException("Core already repaired.");
        
        if (woodBroken && magicWandRepairInfo.WoodRepairInfo.Repaired)
            throw new ValidationException("Wood already repaired.");

        MagicWandRepairInfo = magicWandRepairInfo;
        CoreBroken = coreBroken;
        WoodBroken = woodBroken;
    }
}

