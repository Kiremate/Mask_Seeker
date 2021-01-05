using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MaskSeeker.Generic;
using MaskSeeker.Enums;
[CreateAssetMenu]
public class MaskAbilityStats : ScriptableObject
{
    //Name of the ability
    public string _name;

    // Description of the ability 
    public string _description;

    // Number of turns you must wait till you can use
    // the ability again...
    public int _cooldown;

    public int _cdStat;

    //Amount of health you recover
    public int _heal;

    //Damage that causes the ability
    public int _dmg;

    //Health you recover with basic attacks
    public int _lifeSteal;

    //Increase of a stat
    public int _statUp;

    //Decreas of a stat
    public int _statDown;

    //Status condition applied
    public string _status;

    // Health power ratio of the ability
    public float _healthScale;

    // Ability power ratio of the ability 
    public float _apScale;

    // Attack power ratio of the ability 
    public float _adScale;

    // If its true, is usable, else is locked
    public bool _available;

    // Abilities linked to X Mask
    public EMasks _maskSpellLink;
}
