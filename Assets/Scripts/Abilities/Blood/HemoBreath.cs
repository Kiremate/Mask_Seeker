using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MaskSeeker.Generic;
public class HemoBreath : MaskAbility
{
    [SerializeField]
    private MaskAbilityStats HemoBreathStats;

    public override void ResetCoolDown(int reset)
    {
        HemoBreathStats._cooldown -= reset;
    }

    public override void Use(MaskCarrier from, MaskCarrier to)
    {
        float damage = HemoBreathStats._dmg * from.Stats.AbilityPower;
        to.CurrentHealth -= damage;

        HemoBreathStats._cooldown = HemoBreathStats._cdStat;
        ConsoleLogController._instance.Write(string.Format("{0} used {1}, dealing {2} damage to {3}", from.Name, HemoBreathStats.name, (int)damage, to.Name));
    }

    // Start is called before the first frame update
    void Start()
    {
        // We need to do this to save the reference of the scriptable objects due to SerializeField asignations...
        this.MaskAbilityStats = HemoBreathStats;
    }

   
}
