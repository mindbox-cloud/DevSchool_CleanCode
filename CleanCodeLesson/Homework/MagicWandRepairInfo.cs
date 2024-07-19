namespace CleanCodeLesson.Homework;

public record MagicWandRepairInfo(
    IMagicWand MagicWand,
    RepairInfo CoreRepairInfo, 
    RepairInfo WoodRepairInfo);