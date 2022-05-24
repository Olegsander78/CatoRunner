using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelPopUpScreen : Screen
{
    [SerializeField] private Button _closeBtn;

    public TextMeshProUGUI TextLevelPopUp;

    private void Start()
    {
        _closeBtn.onClick.AddListener(ClosePopUp);
    }

    public void ClosePopUp()
    {
        GameController.Instance.SoundController.PlaySound(SFX.SFXTypeUI.ClickButton);
        GameController.Instance.ScreenController.PopScreen();
        GameController.Instance.ScreenController.PushScreen<SelectLevelsScreen>();
    }

    public void SetText(string Text)
    {
        TextLevelPopUp.text = Text;
    }
}
