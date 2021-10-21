namespace Bettercount.Entities.Dispatchers
{
    public class MockedBettercountDispatcher : IBettercountDispatcher
    {


        public IEnumerable<BettercountPreviewEntity>? GetSubscribedBettercountsByUserId(string uid)
        {
            if(mockedBettercounts.TryGetValue(uid, out var bettercounts))
                return bettercounts;
            return null;
        }

        public MockedBettercountDispatcher()
        {
            
        }


                internal IDictionary<string, IEnumerable<BettercountPreviewEntity>> mockedBettercounts 
        = new Dictionary<string, IEnumerable<BettercountPreviewEntity>>()
        {
            {"aaab2", new List<BettercountPreviewEntity>()
                {
                    new BettercountPreviewEntity()
                    {
                        UId = "a",
                        Name = "Eindovhen"
                    },
                    new BettercountPreviewEntity()
                    {
                        UId = "ab",
                        Name = "Street"
                    },
                }
            },
            {"aaab3", new List<BettercountPreviewEntity>()
                {
                    new BettercountPreviewEntity()
                    {
                        UId = "c",
                        Name = "Paris"
                    },
                    new BettercountPreviewEntity()
                    {
                        UId = "cb",
                        Name = "CNF"
                    },
                }
            },

        };
    }
}