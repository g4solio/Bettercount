namespace Bettercount.Entities
{
    public class TrackedExpense
    {

        public string UId;
        public string Name;
        public double Cost;
        public string Notes;
        public IEnumerable<(User user, double moneyOwed)> Creditors;
        public IEnumerable<(User user, double moneySpendt)> Debtors;

        public IEnumerable<(User user, double lamdaMoney)> ResolveExpense()
        {
            return Creditors.Select(creditor => 
                {
                    var debtor = Debtors.SingleOrDefault(debtor => debtor.user.Equals(creditor.user));
                    if(debtor == default)
                        return creditor;
                    creditor.moneyOwed -= debtor.moneySpendt;
                    return creditor;
                }).Union
                (
                    Debtors
                        .Where(debtor => !Creditors.Any(creditor => creditor.user.Equals(debtor.user)))
                        .Select(debtor => (debtor.user, debtor.moneySpendt * -1))
                );
        }
        
    }
}