using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScreen : Screen
{
    [SerializeField] private Button _playBtn;
    [SerializeField] private Button _settingsBtn;
    [SerializeField] private Button _exitBtn;

    private void Start()
    {
        _playBtn.onClick.AddListener(Play);
        _settingsBtn.onClick.AddListener(OpenSettings);
        _exitBtn.onClick.AddListener(QuitGame);
    }

    public void Play()
    {
        GameController.Instance.ScreenController.PushScreen<SelectLevelsScreen>();
    }

    public void OpenSettings()
    {
        GameController.Instance.ScreenController.PushScreen<SettingsScreen>();
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
