using System;
using System.Collections.Immutable;
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
        return true;
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
    /*
        This is not bad but error prone, try to use "Aggregate" to make it more solid 
    */
    public static Purchase Run(Purchase purchase, Func<Decision> decider)
    {
        var decidedByTeamLead = new DecisionMaker(purchase, Role.Teamlead, decider).Decide();
        var decidedByManager = new DecisionMaker(decidedByTeamLead, Role.Manager, decider).Decide();
        var decidedByGM = new DecisionMaker(decidedByManager, Role.GM, decider).Decide();
        var decidedByCEO = new DecisionMaker(decidedByGM, Role.CEO, decider).Decide();

        return decidedByCEO;
    }
    public static Purchase initialApprovals = ImmutableDictionary.Create<Role, Decision>();

}