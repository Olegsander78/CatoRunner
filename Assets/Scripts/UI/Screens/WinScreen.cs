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
        GameController.Instance.ScreenController.PopScreen();
        GameController.Instance.ScreenController.PushScreen<SelectLevelsScreen>();
    }

    public void GoBackMainMenu()
    {
        GameController.Instance.ScreenController.PopScreen();
        GameController.Instance.ScreenController.PushScreen<MainMenuScreen>();
    }
}
