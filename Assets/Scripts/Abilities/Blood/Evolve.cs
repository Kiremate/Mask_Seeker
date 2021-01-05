using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MaskSeeker.Generic;
public class Evolve : MaskAbility
{
    [SerializeField]
    private MaskAbilityStats EvolveStats;

    public override void ResetCoolDown(int reset)
    {
        EvolveStats._cooldown -= reset;
    }

    public override void Use(MaskCarrier from, MaskCarrier to)
    {
        from.MaxHealth += EvolveStats._statUp;
        from.CurrentHealth += EvolveStats._statUp;
        from.Stats.AttackPower += EvolveStats._statUp;
        from.Stats.AbilityPower += EvolveStats._statUp;

        EvolveStats._cooldown = EvolveStats._cdStat;
        ConsoleLogController._instance.Write(string.Format("{0} used {1}, gaining {2} attack power , {3} ability power and {4} max health", from.Name,
           EvolveStats.name, EvolveStats._statUp, EvolveStats._statUp, EvolveStats._statUp));
    }


    // Start is called before the first frame update
    void Start()
    {
        // We need to do this to save the reference of the scriptable objects due to SerializeField asignations...
        this.MaskAbilityStats = EvolveStats;
    }

}
