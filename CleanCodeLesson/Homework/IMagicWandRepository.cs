namespace CleanCodeLesson.Homework;

public interface IMagicWandRepository
{
    Task Save(MagicWand wand);
}