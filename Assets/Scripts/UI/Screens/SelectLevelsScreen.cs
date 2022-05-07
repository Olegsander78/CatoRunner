using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelsScreen : Screen
{
    [SerializeField] private List<Button> _levelBtn;
    [SerializeField] private Button _backBtn;

    [SerializeField] private List<UILevel> _uiLevelsList = new List<UILevel>();
    public List<UILevel> UILevelsList { get => _uiLevelsList; set => _uiLevelsList = value; }

    private void Start()
    {
        for (int i = 0; i < _levelBtn.Count; i++)
        {
            int numLevel = i + 1;
            _levelBtn[i].onClick.AddListener(() => StartLevel(numLevel));
        }

        _backBtn.onClick.AddListener(GoBackMainMenu);
    }


    public void StartLevel(int level)
    {
        if (GameController.Instance.LevelController.LevelsNoteList[level-1].LevelNumber == level &&
                !GameController.Instance.LevelController.LevelsNoteList[level-1].Locked)
        {
            GameController.Instance.SoundController.PlaySound(SFX.SFXTypeUI.ClickButton);
            GameController.Instance.ScreenController.PopScreen();
            GameController.Instance.LoadLevel(level);
        }
        else
        {
            throw new Exception("Level locked!!!");
            //ToDo Popup
        }
    }

    public void GoBackMainMenu()
    {
        GameController.Instance.SoundController.PlaySound(SFX.SFXTypeUI.ClickButton);
        GameController.Instance.ScreenController.PushScreen<MainMenuScreen>();
    }

    private void OnEnable()
    {
        UpdateUISelectLevels();
    }

    [ContextMenu("UpdateUILevel")]
    public void UpdateUISelectLevels()
    {
        for (int i = 1; i < UILevelsList.Count; i++)
        {
            if (UILevelsList[i].LevelUINumber == GameController.Instance.LevelController.LevelsNoteList[i].LevelNumber)
            {
                UILevelsList[i].LockImage.gameObject.SetActive(GameController.Instance.LevelController.LevelsNoteList[i].Locked);
                UILevelsList[i].UnLockImage.gameObject.SetActive(!GameController.Instance.LevelController.LevelsNoteList[i].Locked);
                Debug.Log(UILevelsList[i].LevelUINumber);
                Debug.Log(GameController.Instance.LevelController.LevelsNoteList[i].Locked);
            }
        }
    }    
}
