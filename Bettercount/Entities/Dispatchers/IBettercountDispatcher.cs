namespace Bettercount.Entities.Dispatchers
{
    public interface IBettercountDispatcher
    {
         public IEnumerable<BettercountPreviewEntity>? GetSubscribedBettercountsByUserId(string uid);
    }
}