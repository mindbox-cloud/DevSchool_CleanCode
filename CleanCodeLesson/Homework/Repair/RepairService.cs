namespace CleanCodeLesson.Homework.Repair;

public class RepairService
{
    public RepairStatus Repair(MagicWand magicWand, RepairRequest request)
    {
        switch (request)
        {
            case { RepairPart: RepairPart.Core }:
                if (!magicWand.CoreRepairInfo.CanBeRepaired()) return RepairStatus.DeclinedAsAlreadyRepaired;
                // Чиним
                return magicWand.CoreRepairInfo.MarkAsRepaired();
            
            case { RepairPart: RepairPart.Material }:
                if (!magicWand.MaterialRepairInfo.CanBeRepaired()) return RepairStatus.DeclinedAsAlreadyRepaired;
                // Чиним
                return magicWand.MaterialRepairInfo.MarkAsRepaired();
            
            default: throw new ArgumentOutOfRangeException(nameof(request.RepairPart));
        }
    }
}