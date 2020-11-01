using System;
using System.Collections.Immutable;
using System.Linq;
using Purchase = System.Collections.Immutable.ImmutableDictionary<Role, Decision>;

public enum Role { Teamlead, Manager, GM, CEO }
public enum Decision { Approved, Rejected }

public class DecisionMaker 
{    
    private Purchase purchase;
    private Role role;
    private Func<Decision> decider;

    public DecisionMaker(
        Purchase purchase, 
        Role role,
        Func<Decision> decider
    ) {
        this.purchase = purchase;
        this.role = role;
        this.decider = decider;
    }

    // check all roles approve of the purchase
    bool ApprovedBy(params Role[] roles) 
    {
        return roles.All(r => this.purchase.ContainsKey(r) && purchase[r] == Decision.Approved);
    }

    public Purchase Decide() 
    {
        switch (this.role) {
            case Role.CEO: 
                if (!this.ApprovedBy(Role.GM, Role.Manager, Role.Teamlead)) {
                    return this.purchase;
                }
                break;
            case Role.GM:
                if (!this.ApprovedBy(Role.Manager, Role.Teamlead)) {
                    return this.purchase;
                }
                break;
            case Role.Manager:
                if (!this.ApprovedBy(Role.Teamlead)) {
                    return this.purchase;
                }
                break;
        }

        return this.purchase.SetItem(this.role, this.decider());
    }
}

// a chain of processors taking turn at one object
public static class Pipeline 
{
    public static Purchase Run(Purchase purchase, Func<Decision> decider)
    {
        return new [] {
            Role.Teamlead,
            Role.Manager,
            Role.GM,
            Role.CEO
        }.Aggregate(purchase, (pur, role) => new DecisionMaker(pur, role, decider).Decide());
    }

    public static Purchase initialApprovals = ImmutableDictionary.Create<Role, Decision>();
}