using Xunit;
using Bettercount.Entities;
using System;
namespace Bettercount.Tests;

public class UnitTest1
{
    [Fact]
    public void ExpenseTest()
    {
        var bettercount = new BettercountEntity();

        bettercount.AddExpense(new TrackedExpense()
            {
                Creditors = new (User, double) []
                {
                    (new User()
                    {
                        UId = "aa"
                    }, 50),
                    (new User()
                    {
                        UId = "ab"
                    }, 75)
                },
                Debtors = new (User, double) []
                {
                    (new User()
                    {
                        UId = "aa"
                    }, 50),
                    (new User()
                    {
                        UId = "ac"
                    }, 75)
                }
            }
        );

        Assert.Equal(bettercount.TrackedDebt[new User()
        {
            UId="aa"
        }], 0.00);
        Assert.Equal(bettercount.TrackedDebt[new User()
        {
            UId="ab"
        }], 75.00);
        Assert.Equal(bettercount.TrackedDebt[new User()
        {
            UId="ac"
        }], -75.00);

    }
}