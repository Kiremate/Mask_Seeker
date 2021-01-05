using UnityEngine;
using MaskSeeker.Interfaces;
using MaskSeeker.Controllers;
namespace MaskSeeker.Generic
{

    public class MaskCarrier : MonoBehaviour, IUsableActions
    {
        [SerializeField]
        public Mask _currentMask;
        [SerializeField]
        protected Stats _stats;
        [SerializeField]
        private float _currentHealth;
        [SerializeField]
        private float _maxHealth;
        [SerializeField]
        public MaskCarrier _enemy;
        // Name of the player
        private string _name;
        //Scale
        private float _basicAttackScale = 0.5f;

        public string _status;



        public string Name { get => _name; set => _name = value; }
        public Stats Stats { get => _stats; set => _stats = value; }
        public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }


        private void Awake()
        {
            this.Name = "Freezing Mask";
            _stats = new Stats(20, 20, 30);


            // LOAD ALL THE ABILITIES STATS
            for (int i = 0; i < this._currentMask.Abilities.Count; ++i)
            {
                MaskAbility a = (MaskAbility)this._currentMask.Abilities[i].GetComponent(typeof(MaskAbility));
                a.MaskAbilityStats = Resources.Load<MaskAbilityStats>("ScriptableObjects/Stats/" + _currentMask.name + "/" + a.name);
            }
        }

        private void Start()
        {


        }



        public float CurrentHealth
        {
            get => _currentHealth;
            set
            {
                // TODO Better Range check
                    this._currentHealth = value;

                if (this._currentHealth < 0)
                    this._currentHealth = 0;
                else if (this.CurrentHealth > this.MaxHealth)
                    this._currentHealth = this.MaxHealth;
            }
        }




        // Update
        private void Update()
        {

        }















        public float BasicAttackNoTurnPass()
        {
            // It hits you with a 5% of your attPower
            _enemy._currentHealth -= Stats.AttackPower * _basicAttackScale;
            return Stats.AttackPower * _basicAttackScale;
        }

        // IUSABLE FUNCTIONS
        public void BasicAttack()
        {
            // It hits you with a 5% of your attPower
            float damage  = Stats.AttackPower * _basicAttackScale;

            _enemy._currentHealth -= damage;
            ConsoleLogController._instance.Write(string.Format("{0} used {1}, dealing {2} damage to {3}", this.Name, "Basic Attack", (int)damage, this._enemy.Name));
            // Pass the turn and reset the CD's
            GameController._instance.PassTurn();
            ResetCooldown();
        }

        public void Die()
        {
            throw new System.NotImplementedException();
        }

        public void UseFirstAbility()
        {
            MaskAbility ability = (MaskAbility)_currentMask.Abilities[0].GetComponent(typeof(MaskAbility));
            ability.Use(this, this._enemy);
            // Pass the turn and reset the CD's
            GameController._instance.PassTurn();
            ResetCooldown();
        }

        public void UseSecondAbility()
        {
            MaskAbility ability = (MaskAbility)_currentMask.Abilities[1].GetComponent(typeof(MaskAbility));
            ability.Use(this, this._enemy);
            // Pass the turn and reset the CD's
            GameController._instance.PassTurn();
            ResetCooldown();
        }

        public void UseThirdAbility()
        {
            MaskAbility ability = (MaskAbility)_currentMask.Abilities[2].GetComponent(typeof(MaskAbility));
            ability.Use(this, this._enemy);
            // Pass the turn and reset the CD's
            GameController._instance.PassTurn();
            ResetCooldown();
        }

        public void UseFourthAbility()
        {
            MaskAbility ability = (MaskAbility)_currentMask.Abilities[3].GetComponent(typeof(MaskAbility));
            ability.Use(this, this._enemy);
            // Pass the turn and reset the CD's
            GameController._instance.PassTurn();
            ResetCooldown();
        }
        // Reset CD's 1 turn?
        public void ResetCooldown()
        {
            for(int i=0; i<_currentMask.Abilities.Count;++i)
            {
                MaskAbility ability = (MaskAbility)_currentMask.Abilities[i].GetComponent(typeof(MaskAbility));
                ability.ResetCoolDown(1);
            }
        }




    }
}
