using System.Collections.Generic;
using System.Linq;

public static class InflatedIncome
{
    /*
        Calculate total income over the years in regards to inflation
        Presumed inflation rate is constant
        See spec for example
        Tip: you'll need the Aggregate function
    */
    public static decimal Calculate(IEnumerable<decimal> annualIncome, decimal inflationRate) 
    {
        return annualIncome
                .Reverse()
                .Aggregate(0m, (tot, cur) => tot * (1 + inflationRate) + cur);
    }
}