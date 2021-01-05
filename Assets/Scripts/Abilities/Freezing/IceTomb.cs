using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MaskSeeker.Generic;

public class IceTomb : MaskAbility
{

    [SerializeField]
    private MaskAbilityStats IceTombStats;

    public override void ResetCoolDown(int reset)
    {
        IceTombStats._cooldown -= reset;

    }

    public override void Use(MaskCarrier from, MaskCarrier to)
    {
        float damage = IceTombStats._dmg * from.Stats.AbilityPower;
        to.CurrentHealth -= damage;
        if (Random.Range(0, 6) == 5)
        {
           to._status = IceTombStats._status;
        }

        IceTombStats._cooldown = IceTombStats._cdStat;
        ConsoleLogController._instance.Write(string.Format("{0} used {1}, dealing {2} damage to {3}", from.Name, IceTombStats.name, (int)damage, to.Name));
    }
    // Start is called before the first frame update
    void Start()
    {
        // We need to do this to save the reference of the scriptable objects due to SerializeField asignations...
        this.MaskAbilityStats = IceTombStats;
    }

}
