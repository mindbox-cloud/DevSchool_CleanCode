namespace CleanCodeLesson.Homework.Sales;

public interface IMagicWandRepository
{
    Task Save(MagicWand wand);
}