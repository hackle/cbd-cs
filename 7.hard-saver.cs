using System.Collections.Generic;
using System.Linq;

public static class HardSaver
{
    /*
        Calculate total income over the years in regards to interest
        Presumed interest rate is constant
        See spec for example
        Tip: you'll need the Aggregate function
    */
    public static decimal AllWithInterest(IEnumerable<decimal> annualIncome, decimal interestRate) 
    {
        return annualIncome
                .Reverse()
                .Aggregate(0m, (tot, cur) => tot * (1 + interestRate) + cur);
    }
}