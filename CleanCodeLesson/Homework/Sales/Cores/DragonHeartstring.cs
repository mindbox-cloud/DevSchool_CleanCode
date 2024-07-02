namespace CleanCodeLesson.Homework.Sales;

public record DragonHeartstring(DragonType DragonType) : Core(new Price(2m * DragonType.PriceMultiplier));