using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MaskSeeker.Enums;
namespace MaskSeeker.Generic
{
    [CreateAssetMenu]
    [System.Serializable]

    
    public class Mask : ScriptableObject
    {

        public List<GameObject> Abilities;
        // Enum of the mask
        EMasks _Emask = EMasks.None;
        [SerializeField]
        private Color _MaskColor;
        // Current Affinity - Starts at 0 %
        protected float _affinity = 0;
        [SerializeField]
        public AudioClip _maskClip;


        // Setters n getters
        public EMasks Emask { get => _Emask; set => _Emask = value; }
        public Color MaskColor { get => _MaskColor; set => _MaskColor = value; }

        public float GetAffinity()
        {
            return this._affinity;
        }

        // Affinity cannot surpass 100%
        public void SetAffinity(float value)
        {
            if (value >= 100)
                _affinity = 100;
            else
                _affinity = value;
        }

        // Constructor

        public Mask(EMasks mask, Color maskColor, float affinity)
        {

            this._Emask = mask;
            this._MaskColor = maskColor;
            this.SetAffinity(affinity);
        }






        // Increases affinity, increased when dealing dmg or healing 
        public void IncreaseAffinity(float amount)
        {
            SetAffinity(this._affinity + amount);
        }
    }
}