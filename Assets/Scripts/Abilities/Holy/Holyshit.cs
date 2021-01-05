using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MaskSeeker.Generic;
public class Holyshit : MaskAbility
{
    [SerializeField]
    private MaskAbilityStats HolyShitStats;

    public override void ResetCoolDown(int reset)
    {
        HolyShitStats._cooldown -= reset;
    }

    public override void Use(MaskCarrier from, MaskCarrier to)
    {
        int healing = HolyShitStats._heal;
        from.CurrentHealth += healing;

        HolyShitStats._cooldown = HolyShitStats._cdStat;
        ConsoleLogController._instance.Write(string.Format("{0} used {1}, healing himself {2} healthpoints", from.Name, HolyShitStats.name, healing));

    }

}