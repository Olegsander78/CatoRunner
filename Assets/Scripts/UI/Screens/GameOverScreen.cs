using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : Screen
{
    [SerializeField] public Button _replayBtn;
    [SerializeField] public Button _exitBtn;


    private void Start()
    {
        _replayBtn.onClick.AddListener(ReplayLevel);
        _replayBtn.onClick.AddListener(GoBackMainMenu);
    }

    public void ReplayLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameController.Instance.LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoBackMainMenu()
    {
        GameController.Instance.ScreenController.PushScreen<MainMenuScreen>();
    }

}
