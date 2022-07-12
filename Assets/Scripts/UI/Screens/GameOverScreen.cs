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
        _exitBtn.onClick.AddListener(GoBackMainMenu);
    }

    public void ReplayLevel()
    {
        GameController.Instance.SoundController.StopSound();
        GameController.Instance.SoundController.PlaySound(SFX.SFXTypeUI.ClickButton);
        GameController.Instance.ResetLevel(SceneManager.GetActiveScene().buildIndex, GameController.Instance.LevelController.CurrentLevel);
    }

    public void GoBackMainMenu()
    {
        GameController.Instance.SoundController.StopSound();
        GameController.Instance.SoundController.PlaySound(SFX.SFXTypeUI.ClickButton);
        GameController.Instance.ScreenController.PopScreen();
        SceneManager.LoadScene("Menu");
        //GameController.Instance.ScreenController.PushScreen<MainMenuScreen>();
        //GameController.Instance.SoundController.PlayBGMusic(BGMusic.MusicType.MainMenu);
    }
    private void OnEnable()
    {
        if (GameObject.Find("_Player"))
            GameObject.Find("_Player").GetComponentInChildren<PlayerController>().enabled = false;
    }

}
