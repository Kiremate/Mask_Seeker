using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaskSeeker.Generic
{
    public class Stats
    {
        // Physical Scale
        private float _attackPower = 0;
        // Ability Scale
        private float _abilityPower = 0;
        // Health As a STAT
        private float _healtPoints = 0;

        public Stats(float attackPower, float abilityPower, float healtPoints)
        {
            _attackPower = attackPower;
            _abilityPower = abilityPower;
            _healtPoints = healtPoints;
        }

        public float AttackPower { get => _attackPower; set => _attackPower = value; }
        public float AbilityPower { get => _abilityPower; set => _abilityPower = value; }
        public float HealtPoints { get => _healtPoints; set => _healtPoints = value; }

        // Modifiers can receive negative values
        private void ModifyAd(float value)
        {
            this.AttackPower += value;

        }
        private void ModifyAp(float value)
        {
            this.AbilityPower += value;
        }

        private void ModifyHp(float value)
        {
            this.HealtPoints += value;
        }

        // Overrided ToString so we can se current stats ordered
        public override string ToString()
        {
            string result = string.Format("Current Stats: \n" +
                "Current Attack Power: {0} \n" +
                "Current Ability Power: {1} \n" +
                "Current Health Points: {2} \n",
                             this.AttackPower, this.AbilityPower, this.HealtPoints);
            return result;
        }


    }
}