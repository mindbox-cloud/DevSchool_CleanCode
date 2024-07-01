namespace CleanCodeLesson.Homework;

public class MagicWandService(IMagicWandRepository repository)
{
    public async Task Save(MagicWand wand)
    {
        await repository.Save(wand);
    }
}