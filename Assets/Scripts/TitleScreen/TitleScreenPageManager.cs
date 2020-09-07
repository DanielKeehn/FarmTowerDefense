using UnityEngine;

namespace Menu {
    public class TitleScreenPageManager : MonoBehaviour {

        public PageController pageController;

#if UNITY_EDITOR
    public void GoToMainPage() {
        pageController.TurnPageOn(PageType.TitleScreen_Main);
        pageController.TurnPageOff(PageType.TitleScreen_Credits);
    }

    public void GoToCredits() {
        pageController.TurnPageOn(PageType.TitleScreen_Credits);
        pageController.TurnPageOff(PageType.TitleScreen_Main);

    }
#endif

    }

}