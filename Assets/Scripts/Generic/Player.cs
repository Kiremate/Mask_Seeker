using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace MaskSeeker.Generic
{
    // TODO Player as a Singleton
    public class Player : MaskCarrier
    {
        //TODO 8% of affinity per win
        // If fight longs less than 8 min
        // affinity gained is 15%
        // values may change
    
        // Available masks the user can chose to play with
        private List<Mask> _availableMasks;
        // Affinity Gain Ratio
        [SerializeField]
        private float _AffinityGainRatio;
        [SerializeField]
        // Affinity Increase base
        private int _baseAffinityIncrease;
        // Affinity Gained in the current combat
        private float _affinityGained;

        

        // INTERFACE
        [SerializeField]
        private Image _affinitybar;
        // AUDIO
        [SerializeField]
        private AudioSource _maskOST;
        


        // Getters n Setters

        public List<Mask> AvailableMasks { get => _availableMasks; set => _availableMasks = value; }
        public float AffinityGainRatio { get => _AffinityGainRatio; set => _AffinityGainRatio = value; }
        public int BaseAffinityIncrease { get => _baseAffinityIncrease; set => _baseAffinityIncrease = value; }
        public float AffinityGained { get => _affinityGained; set => _affinityGained = value; }

        //Singleton
        public static Player instance {
            get;
            private set;
        }
        
        


        private void Awake()
        {
            //Avoid more than one players 
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
         

            this.Name = "Player";
            this._availableMasks = new List<Mask>();
            this._AffinityGainRatio = 0.01f;
            this._baseAffinityIncrease = 1;
            this._affinityGained = 0;
            this._stats = new Stats(20, 20, 30);

            // LOAD THE MASK
            Mask mask = Resources.Load<Mask>("ScriptableObjects/Masks/Freezing_Mask");
            this._currentMask = mask;

            // SOUND CLIP
            this._maskOST.clip = this._currentMask._maskClip;



            // LOAD ALL THE ABILITIES STATS

            for (int i = 0; i < this._currentMask.Abilities.Count; ++i)
            {
                MaskAbility a = (MaskAbility)this._currentMask.Abilities[i].GetComponent(typeof(MaskAbility));
                a.MaskAbilityStats = Resources.Load<MaskAbilityStats>("ScriptableObjects/Stats/" + _currentMask.name + "/" + a.name);
            }
          
        }



        private void Start()
        {
            _maskOST.Play();
            StartCoroutine(StartGainingAffinity());


        }

        


        private void Update()
        {
            // Interface --- FILL AMOUNT GOES FROM 0 TO 1
            _affinitybar.fillAmount = (_currentMask.GetAffinity() / 100);





        }


        // This is called when the affinity reachs one of those lvls
        private void Evolve()
        {

        }

        private void SwitchCurrentMask(Mask mask)
        {
            // We remove the mask from the avalaible mask list
            _availableMasks.Remove(mask);
            // We add the current mask back to the avalaible list
            _availableMasks.Add(this._currentMask);
            // We finally asign the current mask the mask passed by value
            this._currentMask = mask;
        }

        IEnumerator StartGainingAffinity()
        {
            while(_affinityGained <= 25)
            {
                AffinityGained += _AffinityGainRatio * _baseAffinityIncrease;
                this._currentMask.IncreaseAffinity(_AffinityGainRatio * _baseAffinityIncrease);
                yield return new WaitForSeconds(.5f);
            }
            yield return null;
        }

       




    }
}