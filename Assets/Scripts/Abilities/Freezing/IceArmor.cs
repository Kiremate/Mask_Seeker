using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MaskSeeker.Generic;
public class IceArmor : MaskAbility
{
    // Start is called before the first frame update
    [SerializeField]
    private MaskAbilityStats IceArmorStats;

    public override void Use(MaskCarrier from, MaskCarrier to)
    {
       from.MaxHealth += IceArmorStats._statUp;
       from.CurrentHealth += IceArmorStats._statUp;

        IceArmorStats._cooldown = IceArmorStats._cdStat;
        ConsoleLogController._instance.Write(string.Format("{0} used {1}, gaining {2} max health", from.Name,
            IceArmorStats.name, IceArmorStats._statUp));
    }
    public void ResetIceArmor(MaskCarrier from, MaskCarrier to)
    {
        if (IceArmorStats._cooldown == IceArmorStats._cdStat - 1)
        {
            from.MaxHealth -= IceArmorStats._statUp;
            from.CurrentHealth -= IceArmorStats._statUp;
        }
    }

    void Start()
    {
        // We need to do this to save the reference of the scriptable objects due to SerializeField asignations...
        this.MaskAbilityStats = IceArmorStats;
    }


    public override void ResetCoolDown(int reset)
    {
        IceArmorStats._cooldown -= reset;
    }
}
