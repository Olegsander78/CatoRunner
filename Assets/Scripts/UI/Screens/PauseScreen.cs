using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreen : Screen
{
    [SerializeField] public Button _resumeBtn;
    [SerializeField] public Button _replayBtn;
    [SerializeField] public Button _exitBtn;


    private void Start()
    {
        _resumeBtn.onClick.AddListener(Resume);
        _replayBtn.onClick.AddListener(ReplayLevel);
        _exitBtn.onClick.AddListener(GoBackMainMenu);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        GameController.Instance.ScreenController.PopScreen();
        GameController.Instance.ScreenController.PushScreen<HUDScreen>();
    }

    public void ReplayLevel()
    {
        //Time.timeScale = 1f;
        //GameController.Instance.ScreenController.PopScreen();
        //GameController.Instance.LoadLevel(SceneManager.GetActiveScene().buildIndex);
        //GameController.Instance.ScreenController.PushScreen<HUDScreen>();
        //GameController.Instance.PlayerProfile.Score = 0;

        GameController.Instance.ResetLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoBackMainMenu()
    {
        GameController.Instance.ScreenController.PopScreen();
        GameController.Instance.ScreenController.PushScreen<MainMenuScreen>();        
    }
}
