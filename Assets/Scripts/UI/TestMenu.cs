using UnityEngine;

namespace Menu {
    public class TestMenu : MonoBehaviour {

        public PageController pageController;

#if UNITY_EDITOR
    private void Update() {
        if (Input.GetKeyUp(KeyCode.F)) {
            pageController.TurnPageOn(PageType.Upgrade);
        }
        if (Input.GetKeyUp(KeyCode.G)) {
            pageController.TurnPageOn(PageType.Attack);
        }
        if (Input.GetKeyUp(KeyCode.H)) {
            pageController.TurnPageOn(PageType.Pause);
        }
        if (Input.GetKeyUp(KeyCode.J)) {
            pageController.TurnPageOn(PageType.Lose);
        }
    }
#endif

    }

}