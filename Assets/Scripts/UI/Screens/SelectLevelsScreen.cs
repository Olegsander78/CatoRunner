using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelsScreen : Screen
{
    [SerializeField] private List<Button> _levelBtn;
    [SerializeField] private Button _backBtn;

    public LevelController.LevelsNote LevelsNote;


    [SerializeField] private List<UILevel> _uiLevelsList = new List<UILevel>();
    public List<UILevel> UILevelsList { get => _uiLevelsList; set => _uiLevelsList = value; }

    private void Start()
    {
        for (int i = 1; i < UILevelsList.Count; i++)
        {
            if (UILevelsList[i].LevelUINumber == LevelsNote.LevelNumber)
            {
                UILevelsList[i].LockImage.gameObject.SetActive(LevelsNote.Locked);
                UILevelsList[i].UnLockImage.gameObject.SetActive(!LevelsNote.Locked);
            }

        }

        for (int i = 0; i < _levelBtn.Count; i++)
        {
            int numLevel = i + 1;
            _levelBtn[i].onClick.AddListener(() => SelectLevel(numLevel));
        }

        _backBtn.onClick.AddListener(GoBackMainMenu);
    }

    public void SelectLevel(int level)
    {
        GameController.Instance.SoundController.PlaySound(SFX.SFXTypeUI.ClickButton);        
        GameController.Instance.ScreenController.PopScreen();
        GameController.Instance.LoadLevel(level);
    }

    public void GoBackMainMenu()
    {
        GameController.Instance.SoundController.PlaySound(SFX.SFXTypeUI.ClickButton);
        GameController.Instance.ScreenController.PushScreen<MainMenuScreen>();
    }

    
}
