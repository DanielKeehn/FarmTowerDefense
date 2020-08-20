using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menu {
    public class UIManager : MonoBehaviour {
        private SwitchBetweenAttackAndSpawnMode gameManager;
        public PageController pageController;

        // Start is called before the first frame update
        void Start()
        {
            try {
                gameManager = GameObject.FindWithTag("GameManager").GetComponent<SwitchBetweenAttackAndSpawnMode>();
                gameManager.switchFromAttackToSpawn += SwitchFromAttackToSpawnUI;
                gameManager.switchFromSpawnToAttack += SwitchFromSpawnToAttackUI;
            } catch {
                throw new System.ArgumentException("Couldn't Add updateStateUI() Function To Events");
            }

            pageController.TurnPageOn(PageType.Attack);           
        }

        public void SwitchFromAttackToSpawnUI() {
            pageController.TurnPageOff(PageType.Attack, PageType.Spawn);
        }

        public void SwitchFromSpawnToAttackUI() {
            pageController.TurnPageOff(PageType.Spawn, PageType.Attack);
        }

        public void SwitchToUpgradeModeUI() {
            pageController.TurnPageOff(PageType.Spawn);
            pageController.TurnPageOff(PageType.Attack);
            pageController.TurnPageOff(PageType.Round, PageType.Upgrade);
        }

        public void SwitchToRoundModeUI() {
            pageController.TurnPageOff(PageType.Upgrade, PageType.Round);
            pageController.TurnPageOn(PageType.Attack);
        }

        public void ShowPauseMenuUI() {
            pageController.TurnPageOn(PageType.Pause);
        }

        public void HidePauseMenuUI() {
            pageController.TurnPageOff(PageType.Pause);
        }

        public void ShowLoseStateUI() {
            pageController.TurnPageOff(PageType.Attack);
            pageController.TurnPageOff(PageType.Spawn);
            pageController.TurnPageOff(PageType.Round,PageType.Lose);
        }
    }
}