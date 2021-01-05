using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MaskSeeker.Generic;

public class HolySnap : MaskAbility
{
    [SerializeField]
    private MaskAbilityStats HolySnapStats;

    public override void ResetCoolDown(int reset)
    {
        HolySnapStats._cooldown -= reset;
    }

    public override void Use(MaskCarrier from, MaskCarrier to)
    {
        float damage = from.BasicAttackNoTurnPass();
        if (from.CurrentHealth + HolySnapStats._lifeSteal >= from.MaxHealth)
            from.CurrentHealth = from.MaxHealth;
        else
            from.CurrentHealth += HolySnapStats._lifeSteal;

        HolySnapStats._cooldown = HolySnapStats._cdStat;
        ConsoleLogController._instance.Write(string.Format("{0} used {1}, dealing {2} damage to {3} and healing himself {4} ", from.Name, HolySnapStats.name, (int)damage, to.Name, HolySnapStats._lifeSteal));
    }
    // Start is called before the first frame update
    void Start()
    {
        // We need to do this to save the reference of the scriptable objects due to SerializeField asignations...
        this.MaskAbilityStats = HolySnapStats;
    }

   
}
