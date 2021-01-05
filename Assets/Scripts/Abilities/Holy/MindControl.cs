using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MaskSeeker.Generic;




public class MindControl : MaskAbility
{

    [SerializeField]
    private MaskAbilityStats MindControlStats;

    public override void ResetCoolDown(int reset)
    {
        MindControlStats._cooldown -= reset;
    }

    public override void Use(MaskCarrier from, MaskCarrier to)
    {
        //No se como acceder al use de los abilities
        MaskAbility ability = (MaskAbility)to._currentMask.Abilities[Random.Range(0, 4)].GetComponent(typeof(MaskAbility));
        ability.Use(from, to);
        MindControlStats._cooldown = MindControlStats._cdStat;
        ConsoleLogController._instance.Write(string.Format("{0} used {1}", from.Name, MindControlStats.name));

    }


    void Start()
    {
        // We need to do this to save the reference of the scriptable objects due to SerializeField asignations...
        this.MaskAbilityStats = MindControlStats;
    }


}
