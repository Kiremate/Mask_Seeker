using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MaskSeeker.Generic;
public class ScaleChange : MaskAbility
{
    [SerializeField]
    private MaskAbilityStats ScaleChangeStats;

    public override void ResetCoolDown(int reset)
    {
        ScaleChangeStats._cooldown -= reset;
    }

    public override void Use(MaskCarrier from, MaskCarrier to)
    {
        float healing = from.MaxHealth / 10;
        from.CurrentHealth += healing;
        ScaleChangeStats._cooldown = ScaleChangeStats._cdStat;
        ConsoleLogController._instance.Write(string.Format("{0} used {1}, healing himself {2} healthpoints", from.Name, ScaleChangeStats.name, (int)healing, to.Name));
    }

    // Start is called before the first frame update
    void Start()
    {
        // We need to do this to save the reference of the scriptable objects due to SerializeField asignations...
        this.MaskAbilityStats = ScaleChangeStats;
    }

   
}
