using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MaskSeeker.Generic;

public class HolyBeam : MaskAbility
{
    [SerializeField]
    private MaskAbilityStats HolyBeamStats;

    public override void ResetCoolDown(int reset)
    {
        HolyBeamStats._cooldown -= reset;
    }

    public override void Use(MaskCarrier from, MaskCarrier to)
    {
        float damage = HolyBeamStats._dmg * from.Stats.AbilityPower;
        to.CurrentHealth -= damage;
        HolyBeamStats._cooldown = HolyBeamStats._cdStat;
        ConsoleLogController._instance.Write(string.Format("{0} used {1}, dealing {2} damage to {3}", from.Name, HolyBeamStats.name, (int)damage, to.Name));
    }
    // Start is called before the first frame update
    void Start()
    {
        this.MaskAbilityStats = HolyBeamStats;
    }

   
}
