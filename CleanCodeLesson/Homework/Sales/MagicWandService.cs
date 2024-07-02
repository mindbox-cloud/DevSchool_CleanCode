namespace CleanCodeLesson.Homework.Sales;

public class MagicWandService(IMagicWandRepository repository)
{
    public async Task Save(MagicWand wand)
    {
        await repository.Save(wand);
    }

    public void Sell(MagicWand wand, Customer customer)
    {
        if (wand is CollectibleMagicWand collectibleMagicWand)
        {
            if (!customer.IsAdult) 
                throw new InvalidOperationException("Customer must be an adult to purchase a collectible wand");

            var newOwner = new Owner(customer.FirstName, customer.LastName);
            collectibleMagicWand.OwnersHistory.Owners.Add(newOwner);
        }
        
        // продать палочку
    }
}