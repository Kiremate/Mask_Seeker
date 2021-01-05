using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MaskSeeker.Generic;
namespace MaskSeeker.Controllers
{
    public class AIController : MonoBehaviour
    {
        [SerializeField]
        private MaskCarrier _carrierBot;

        private Coroutine attackCorroutine = null;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // ARTIFICIAL INTELLIGENCE 
            // YIKES 
            if (GameController._instance._currentTurn == Enums.ETurns.ENEMY_TURN && attackCorroutine == null)
            {
                attackCorroutine = StartCoroutine(RandomAbility());
            }
        }

        IEnumerator RandomAbility()
        {
            int rand = Random.Range(0, 5);
            yield return new WaitForSeconds(5);
            switch (rand)
            {
                case 0:
                    _carrierBot.UseFirstAbility();
                    break;
                case 1:
                    _carrierBot.UseSecondAbility();
                    break;
                case 2:
                    _carrierBot.UseThirdAbility();
                    break;
                case 3:
                    _carrierBot.UseFourthAbility();
                    break;

                default:
                    _carrierBot.BasicAttack();
                    break;

            }
            this.attackCorroutine = null;
            yield return null;
        }
        
    }
}