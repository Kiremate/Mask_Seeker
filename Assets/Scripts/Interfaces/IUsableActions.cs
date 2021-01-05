using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaskSeeker.Interfaces
{
    // Basic actions that a maskcarrier can perform
    interface IUsableActions
    {
        // Basic attack
        void BasicAttack();

        // Use First of the array
        void UseFirstAbility();
        // Use Second
        void UseSecondAbility();
        // Use Third
        void UseThirdAbility();
        // Use Fourth
        void UseFourthAbility();



        // Is executed when he carrier dies
        void Die();
    }
}