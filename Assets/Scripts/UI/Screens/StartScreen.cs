using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : Screen
{
    [SerializeField] private Button _playBtn;

    private void Start()
    {
        _playBtn.onClick.AddListener(Play);
    }

    public void Play()
    {
        GameController.Instance.SoundController.PlaySound(SFX.SFXTypeUI.ClickButton);
        GameController.Instance.ScreenController.PushScreen<MainMenuScreen>();
    }
}
