using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : Screen
{
    [SerializeField] public Button _replayBtn;
    [SerializeField] public Button _exitBtn;


    public void ReplayLevel()
    {

    }

    public void GoBackMainMenu()
    {
        GameController.Instance.ScreenController.PushScreen<MainMenuScreen>();
    }

}
