namespace CleanCodeLesson.Homework.ValueTypes;

public record DragonHeartstringType(decimal Coefficient)
{
    public static DragonHeartstringType HungarianHorntail => new(Constants.DragonCoefficient.HungarianHorntail);
    public static DragonHeartstringType ChineseFireball => new(Constants.DragonCoefficient.ChineseFireball);
    public static DragonHeartstringType RomanianLonghorn => new(Constants.DragonCoefficient.RomanianLonghorn);
    public static DragonHeartstringType NorwegianSpineback => new(Constants.DragonCoefficient.NorwegianSpineback);
}