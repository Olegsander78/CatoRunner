using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevelsScreen : Screen
{
    private const int RESET_TO_LEVEL = 0;

    [SerializeField] private int _offsetBuildIndexScene = 1;
    [Space(15)]
    [SerializeField] private List<Button> _levelBtn;
    [SerializeField] private Button _backBtn;    
    [SerializeField] private Button _resetBtn;    

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
        _resetBtn.onClick.AddListener(ResetLevels);
    }

    public void StartLevel(int level)
    {
        if (GameController.Instance.LevelController.LevelsNoteList[level - 1].LevelNumber == level &&
                !GameController.Instance.LevelController.LevelsNoteList[level - 1].Locked)
        {
            GameController.Instance.SoundController.PlaySound(SFX.SFXTypeUI.ClickButton);
            GameController.Instance.ScreenController.PopScreen();
            GameController.Instance.LoadLevel(level + _offsetBuildIndexScene);
        }
        else
        {
            //Clear text for Level Task 
            UILevelsList[level - _offsetBuildIndexScene].GetComponent<ToolTip>().View.text = "";

            //PopUp for Locked levels
            GameController.Instance.SoundController.PlaySound(SFX.SFXTypeUI.ClickButton);
            GameController.Instance.ScreenController.PushScreen<LevelPopUpScreen>();
            GameController.Instance.ScreenController.PushScreen<LevelPopUpScreen>().SetText("<b>Level " +
                GameController.Instance.LevelController.LevelsNoteList[level - 1].LevelNumber + " is currently locked!</b>\nComplete level " +
                (GameController.Instance.LevelController.LevelsNoteList[level - 1].LevelNumber - 1) + " to unlock it!");            
        }
    }

    public void GoBackMainMenu()
    {
        GameController.Instance.SoundController.PlaySound(SFX.SFXTypeUI.ClickButton);
        GameController.Instance.ScreenController.PushScreen<MainMenuScreen>();
    }

    public void ResetLevels()
    {
        GameController.Instance.LevelController.SaveWithPlayerPref(RESET_TO_LEVEL);

        GameController.Instance.LevelController.LevelsNoteList[0].Locked = false;
        GameController.Instance.LevelController.LevelsNoteList[0].Completed = false;

        for (int i = 1; i < GameController.Instance.LevelController.LevelsNoteList.Count; i++)
        {
            GameController.Instance.LevelController.LevelsNoteList[i].Locked = true;
            GameController.Instance.LevelController.LevelsNoteList[i].Completed = false;
        }

        UILevelsList[0].LockImage.gameObject.SetActive(GameController.Instance.LevelController.LevelsNoteList[0].Locked);
        UILevelsList[0].UnLockImage.gameObject.SetActive(!GameController.Instance.LevelController.LevelsNoteList[0].Locked);

        for (int i = 1; i < UILevelsList.Count; i++)
        {
            UILevelsList[i].LockImage.gameObject.SetActive(GameController.Instance.LevelController.LevelsNoteList[i].Locked);
            UILevelsList[i].UnLockImage.gameObject.SetActive(!GameController.Instance.LevelController.LevelsNoteList[i].Locked);
        }
    }

    private void OnEnable()
    {        
        UpdateUISelectLevels();
    }

    public void UpdateUISelectLevels()
    {
       //FOR PROTOBUF
        //if (GameController.Instance.PlayerProfile.Profile != null)
        //{

        //    for (int i = 1; i < GameController.Instance.LevelController.LevelsNoteList.Count; i++)
        //    {
        //        if (i <= GameController.Instance.PlayerProfile.Profile.LastUnlockLevel)
        //        {
        //            GameController.Instance.LevelController.LevelsNoteList[i].Locked = false;
        //            GameController.Instance.LevelController.LevelsNoteList[i - 1].Completed = true;
        //        }
        //    }
        //}

//#if UNITY_ANDROID
        if (PlayerPrefs.HasKey("LastUnlockLevel"))
        {
            for (int i = 1; i < GameController.Instance.LevelController.LevelsNoteList.Count; i++)
            {
                if (i <= GameController.Instance.LevelController.LoadWithPlayerPref())
                {
                    GameController.Instance.LevelController.LevelsNoteList[i].Locked = false;
                    GameController.Instance.LevelController.LevelsNoteList[i - 1].Completed = true;
                }
            }
        }
        //#endif
        for (int i = 1; i < UILevelsList.Count; i++)
        {
            if (UILevelsList[i].LevelUINumber == GameController.Instance.LevelController.LevelsNoteList[i].LevelNumber)
            {
                UILevelsList[i].LockImage.gameObject.SetActive(GameController.Instance.LevelController.LevelsNoteList[i].Locked);
                UILevelsList[i].UnLockImage.gameObject.SetActive(!GameController.Instance.LevelController.LevelsNoteList[i].Locked);
            }
        }

    }
}
