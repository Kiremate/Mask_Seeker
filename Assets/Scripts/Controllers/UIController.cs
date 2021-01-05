using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using MaskSeeker.Generic;
namespace MaskSeeker.Controllers
{
    public class UIController : MonoBehaviour
    {
        [SerializeField]
        private Player _player;
        [SerializeField]
        private GameObject _AbilitiesPanel;
        // Texts
        [SerializeField]
        private Text[] _playerStatsTexts;
        [SerializeField]
        private Text[] _playerAbilityTexts;
        // Player Interface
        [SerializeField]
        private Text _playerNameText;
        [SerializeField]
        private Text _playerHealthText;
        [SerializeField]
        private Text _maskAffinityText;


        [SerializeField]
        private Image _playerHealthbar;
        [SerializeField]
        private Image _wallpaper;
        // Enemy Interface
        [SerializeField]
        private Text _enemyNameText;
        [SerializeField]
        private Text _enemyHealthText;

        [SerializeField]
        private Image _enemyHealthbar;
        // Buttons
        [SerializeField]
        private Button[] _abilities;
        [SerializeField]
        private Button _basicAttack;
        // Animators
        [SerializeField]
        private Animator _animatorWallpaper;

        //Singleton
        public static UIController _instance
        {
            get;
            private set;
        }

        // Start is called before the first frame update
        void Start()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(gameObject);
        }

        // Update is called once per frame
        void Update()
        {


            // Updates Player
            UpdatePlayerInterface();
            // Updates Enemy
            UpdateEnemyInterface();


         


        }



        // 0 for health
        // 1 for ad
        // 2 for ap
        private void UpdateStatTexts(int pos)
        {
            switch (pos)
            {
                case 0:
                    _playerStatsTexts[pos].text = _player.Stats.HealtPoints.ToString();
                    break;
                case 1:
                    _playerStatsTexts[pos].text = _player.Stats.AttackPower.ToString();
                    break;
                case 2:
                    _playerStatsTexts[pos].text = _player.Stats.AbilityPower.ToString();
                    break;
            }
        }

        private void UpdatePlayerAbilityButtons()
        {
            foreach (Button b in _abilities)
                b.targetGraphic.color = _player._currentMask.MaskColor;

            for (int i = 0; i < _playerAbilityTexts.Length; ++i)
            {
                MaskAbility a = (MaskAbility)Player.instance._currentMask.Abilities[i].GetComponent(typeof(MaskAbility));
                _playerAbilityTexts[i].text = a.name;
            }

        }


        private void UpdatePlayerInterface()
        {

            // Texts
            _playerNameText.text = _player.Name;
            _playerHealthText.text = string.Format("{0} / {1}", _player.CurrentHealth, _player.MaxHealth);
            _maskAffinityText.text = "Mask Affinity " + _player._currentMask.GetAffinity().ToString("0.00") + " %";
            // Healthbar
            if (_player.CurrentHealth / _player.MaxHealth < 0.25f)
                _playerHealthbar.color = Color.red;
            else
                _playerHealthbar.color = new Color(0.8138738f, 1, 0);
            _playerHealthbar.fillAmount = _player.CurrentHealth / _player.MaxHealth;

            // Stats
            // Update Stat Texts
            for (int i = 0; i < _playerStatsTexts.Length; ++i)
                UpdateStatTexts(i);

            // Abilities
            // Update Ability Interface
            UpdatePlayerAbilityButtons();

        }

        private void UpdateEnemyInterface()
        {
            // Texts
            _enemyNameText.text = _player._enemy.Name;
            _enemyHealthText.text = string.Format("{0} / {1}", _player._enemy.CurrentHealth, _player._enemy.MaxHealth);
            // Healthbar
            if (_player._enemy.CurrentHealth / _player.MaxHealth < 0.25f)
                _enemyHealthbar.color = Color.red;
            else
                _enemyHealthbar.color = new Color(0.8138738f,1,0);

            _enemyHealthbar.fillAmount = _player._enemy.CurrentHealth / _player._enemy.MaxHealth;

        }

        public void EnemyTurnHideInterface()
        {
            if(GameController._instance._currentTurn == Enums.ETurns.PLAYER_TURN)
                _animatorWallpaper.SetInteger("_currentTurn", 2);
            else
                _animatorWallpaper.SetInteger("_currentTurn", 1);


            _basicAttack.interactable = !_basicAttack.interactable;
            _AbilitiesPanel.SetActive(!_AbilitiesPanel.activeSelf);
        }

    
    }

}