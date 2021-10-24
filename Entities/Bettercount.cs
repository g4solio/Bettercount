namespace Bettercount.Entities
{
    public class BettercountPreviewEntity
    {
        public string UId;
        public string Name;
        
    }

    public class BettercountEntity : BettercountPreviewEntity
    {
        internal ListWithEvents<TrackedExpense> _trackedExpenses = new ListWithEvents<TrackedExpense>();

        public IEnumerable<TrackedExpense> TrackedExpenses {get => _trackedExpenses; internal set => _trackedExpenses = new ListWithEvents<TrackedExpense>(value);}

        public SortedDictionary<User, double> TrackedDebt;

        public BettercountEntity()
        {
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            _trackedExpenses.WhenAdd += OnNewTrackedExpense;
            _trackedExpenses.WhenRemove += OnRemoveTrackedExpense;
        }

        private void OnRemoveTrackedExpense(object? sender, TrackedExpense removedExpense)
        {
            var resolvedExpenses = removedExpense.ResolveExpense();
            foreach(var resolvedExpense in resolvedExpenses)
            {
                TrackedDebt[resolvedExpense.user] -= resolvedExpense.lamdaMoney;
            }
        }

        private void OnNewTrackedExpense(object? sender, TrackedExpense newExpense)
        {
            var resolvedExpenses = newExpense.ResolveExpense();
            foreach(var resolvedExpense in resolvedExpenses)
            {
                TrackedDebt[resolvedExpense.user] += resolvedExpense.lamdaMoney;
            }
        }
    }


    internal class ListWithEvents<T> : List<T> 
    {
        public event EventHandler<T> WhenAdd;
        public new void Add(T newElement)
        {
            WhenAdd.Invoke(this, newElement);     
            base.Add(newElement);
        }

        public event EventHandler<T> WhenRemove;

        public new bool Remove(T removedElement)
        {   
            WhenRemove.Invoke(this, removedElement);
            return base.Remove(removedElement);
        }

        public ListWithEvents(IEnumerable<T> baseList) : base(baseList)
        {

        } 

        public ListWithEvents() : base()
        {

        }


    }

}