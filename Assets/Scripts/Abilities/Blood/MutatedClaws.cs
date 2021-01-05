using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MaskSeeker.Generic;
public class MutatedClaws : MaskAbility
{
    [SerializeField]
    private MaskAbilityStats MutatedClawsStats;

    public override void ResetCoolDown(int reset)
    {
        MutatedClawsStats._cooldown -= reset;

    }

    public override void Use(MaskCarrier from, MaskCarrier to)
    {
        float damage = from.BasicAttackNoTurnPass() * 2;
        from.BasicAttackNoTurnPass();
        
        MutatedClawsStats._cooldown = MutatedClawsStats._cdStat;
        ConsoleLogController._instance.Write(string.Format("{0} used {1}, dealing {2} damage to {3}", from.Name, MutatedClawsStats.name, (int)damage, to.Name));
    }

    // Start is called before the first frame update
    void Start()
    {
        // We need to do this to save the reference of the scriptable objects due to SerializeField asignations...
        this.MaskAbilityStats = MutatedClawsStats;
    }


}
