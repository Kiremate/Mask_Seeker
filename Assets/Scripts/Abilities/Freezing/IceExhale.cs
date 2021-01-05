using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MaskSeeker.Generic;
public class IceExhale : MaskAbility
{

    [SerializeField]
    private MaskAbilityStats IceExhaleStats;

    public override void ResetCoolDown(int reset)
    {
        IceExhaleStats._cooldown -= reset; 
    }

    public override void Use(MaskCarrier from, MaskCarrier to)
    {
        from.Stats.AttackPower += IceExhaleStats._statUp;
        from.Stats.AbilityPower += IceExhaleStats._statUp;

        IceExhaleStats._cooldown = IceExhaleStats._cdStat;
        ConsoleLogController._instance.Write(string.Format("{0} used {1}, gaining {2} attack power and {3} ability power", from.Name,
            IceExhaleStats.name, IceExhaleStats._statUp, IceExhaleStats._statUp));
    }
    public void ResetIceExhale(MaskCarrier from, MaskCarrier to)
    {
        if (IceExhaleStats._cooldown == IceExhaleStats._cdStat - 1)
        {
            from.MaxHealth -= IceExhaleStats._statUp;
            from.CurrentHealth -= IceExhaleStats._statUp;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        // We need to do this to save the reference of the scriptable objects due to SerializeField asignations...
        this.MaskAbilityStats = IceExhaleStats;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
