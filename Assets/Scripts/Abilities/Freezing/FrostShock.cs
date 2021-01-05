using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MaskSeeker.Generic;
public class FrostShock : MaskAbility
{
    [SerializeField]
    private MaskAbilityStats FrostShockStats;

    public override void ResetCoolDown(int reset)
    {
        FrostShockStats._cooldown -= reset;
    }

    public override void Use(MaskCarrier from, MaskCarrier to)
    {
        float damage = FrostShockStats._dmg;
        to.CurrentHealth -= damage;

        FrostShockStats._cooldown = FrostShockStats._cdStat;
        ConsoleLogController._instance.Write(string.Format("{0} used {1}, dealing {2} damage to {3}", from.Name, FrostShockStats.name, (int)damage, to.Name));

    }
    // Start is called before the first frame update
    void Start()
    {
        // We need to do this to save the reference of the scriptable objects due to SerializeField asignations...
        this.MaskAbilityStats = FrostShockStats;
    }

}
