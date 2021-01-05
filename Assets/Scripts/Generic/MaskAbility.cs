using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MaskSeeker.Generic
{
    
    // TODO 37 Abilities
    public abstract class MaskAbility : MonoBehaviour

    {
        private MaskAbilityStats _maskAbilityStats;

        public MaskAbilityStats MaskAbilityStats { get => _maskAbilityStats; set => _maskAbilityStats = value; }

        public abstract void Use(MaskCarrier from, MaskCarrier to);
        public abstract void ResetCoolDown(int reset);

        // public abstract void ToLog();
        

        

    }
}