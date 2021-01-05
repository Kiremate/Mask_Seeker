using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MaskSeeker.Generic;
using MaskSeeker.Enums;
namespace MaskSeeker.Controllers
{
    public class GameController : MonoBehaviour
    {
        // Current Player
        [SerializeField]
        private Player _player;
        // Enemy VS
        [SerializeField]
        private MaskCarrier _enemy;

        // Will determine the combat
        public ETurns _currentTurn;

        // How many turns have been played
        private int _howManyTurns;

        // Avoid the player farm affinity
        public bool afking = false;

        //Singleton
        public static GameController _instance
        {
            get;
            private set;
        }

        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(gameObject);


            // MOCKUP
            _currentTurn = ETurns.PLAYER_TURN;
        }

        // Start is called before the first frame update
        void Start()
        {




        }

        // Update is called once per frame
        void Update()
        {


            Debug.Log("Player: " + _player.Stats.ToString());
            Debug.Log("Enemy: " + _enemy.Stats.ToString());


            Debug.Log("Current Turn: " + this._currentTurn.ToString());

            Debug.Log("Player: " + _player.CurrentHealth);
            Debug.Log("Enemy: " + _enemy.CurrentHealth);

        }

        // TODO avoid farming affinity
        private IEnumerator CheckIfAfk()
        {   // Waits 5 mins if afk then bool to 0
            yield return new WaitForSeconds(300);
            afking = true;
        }

        public void PassTurn()
        {
            if (this._currentTurn == ETurns.PLAYER_TURN)
            {
                UIController._instance.EnemyTurnHideInterface();
                this._currentTurn = ETurns.ENEMY_TURN;
            }
            else
            {
                UIController._instance.EnemyTurnHideInterface();
                this._currentTurn = ETurns.PLAYER_TURN;
            }
        }

    }
}