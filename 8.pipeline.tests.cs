using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using NUnit.Framework;
using Purchase = System.Collections.Immutable.ImmutableDictionary<Role, Decision>;

public class PipelineTests
{
    [Test]
    [TestCaseSource(nameof(Scenarios))]
    public void TryScenarios(string scenario, Purchase purchase, Func<Decision> decider, Purchase expected)
    {
        var actual = Pipeline.Run(purchase, decider);

        Assert.That(actual, Is.EqualTo(expected));
    }

    public static object[][] Scenarios = new object[][]
    {
        new object[]
        { 
            "all proves",
            Pipeline.initialApprovals,
            new Func<Decision>(() => Decision.Approved),
            ImmutableDictionary.CreateRange<Role, Decision>(
                new Dictionary<Role, Decision>
                {
                    { Role.Teamlead, Decision.Approved },
                    { Role.Manager, Decision.Approved },
                    { Role.GM, Decision.Approved },
                    { Role.CEO, Decision.Approved }
                }
            )
        },
        new object[]
        {
            "all rejects",
            Pipeline.initialApprovals,
            new Func<Decision>(() => Decision.Rejected),
            ImmutableDictionary.Create<Role, Decision>().SetItem(Role.Teamlead, Decision.Rejected)
        }
    };
}