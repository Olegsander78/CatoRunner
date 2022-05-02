using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : Screen
{
    [SerializeField] private Button _selectBtn;
    [SerializeField] private Button _backBtn;

    private void Start()
    {
        _selectBtn.onClick.AddListener(SelectLevel);
        _backBtn.onClick.AddListener(GoBackMainMenu);
    }

    public void SelectLevel()
    {
        GameController.Instance.SoundController.StopSound();
        GameController.Instance.SoundController.PlaySound(SFX.SFXTypeUI.ClickButton);
        GameController.Instance.ScreenController.PopScreen();
        GameController.Instance.ScreenController.PushScreen<SelectLevelsScreen>();
        GameController.Instance.SoundController.PlayBGMusic(BGMusic.MusicType.MainMenu);
    }

    public void GoBackMainMenu()
    {
        GameController.Instance.SoundController.StopSound();
        GameController.Instance.SoundController.PlaySound(SFX.SFXTypeUI.ClickButton);
        GameController.Instance.ScreenController.PopScreen();
        GameController.Instance.ScreenController.PushScreen<MainMenuScreen>();
        GameController.Instance.SoundController.PlayBGMusic(BGMusic.MusicType.MainMenu);
    }
}
