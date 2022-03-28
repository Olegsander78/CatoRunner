using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelsScreen : Screen
{
    [SerializeField] private List<Button> _levelBtn;
    [SerializeField] private Button _backBtn;

    private void Start()
    {
        for (int i = 0; i < _levelBtn.Count; i++)
        {
            int numLevel = i + 1;
            _levelBtn[i].onClick.AddListener(() => SelectLevel(numLevel));
        }

        _backBtn.onClick.AddListener(GoBackMainMenu);
    }

    public void SelectLevel(int level)
    {
        GameController.Instance.ScreenController.PopScreen();
        GameController.Instance.LoadLevel(level);
    }

    public void GoBackMainMenu()
    {
        GameController.Instance.ScreenController.PushScreen<MainMenuScreen>();
    }

    
}
