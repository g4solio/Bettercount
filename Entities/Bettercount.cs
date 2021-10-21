namespace Bettercount.Entities
{
    public class BettercountPreviewEntity
    {
        public string UId;
        public string Name;
        
    }

    public class BettercountEntity : BettercountPreviewEntity
    {
        public IEnumerable<TrackedExpenses> TrackedExpenses;


        public IEnumerable<(User user, double debt)> TrackedDebt;
    }

}