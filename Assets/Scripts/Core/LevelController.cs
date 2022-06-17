using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [System.Serializable]
    public class SelectLevelsInUINote
    {
        public int LevelNumber;
        public bool Completed;
        public bool Locked;

        public SelectLevelsInUINote(int id, bool completed, bool locked)
        {
            LevelNumber = id;
            Completed = completed;
            Locked = locked;
        }
    }

    [SerializeField] private List<SelectLevelsInUINote> _levelsNoteList;
    public List<SelectLevelsInUINote> LevelsNoteList { get => _levelsNoteList; set => _levelsNoteList = value; }

    [SerializeField] private Level _currentLevel;
    public Level CurrentLevel => _currentLevel;


    //private void OnEnable()
    //{
    //    if (GameController.Instance.PlayerProfile.Profile != null)
    //    {
    //        Debug.Log("OnEnable - " + GameController.Instance.PlayerProfile.Profile.LastUnlockLevel);


    //        for (int i = 1; i < LevelsNoteList.Count; i++)
    //        {
    //            if (i <= GameController.Instance.PlayerProfile.Profile.LastUnlockLevel)
    //            {
    //                LevelsNoteList[i].Locked = false;
    //                LevelsNoteList[i - 1].Completed = true;
    //            }
    //        }
    //    }
    //}

    //[ContextMenu("LoadUILevel")]
    //public void LoadUILevelsNote()
    //{
    //    for (int i = 1; i < LevelsNoteList.Count; i++)
    //    {
    //        if (i <= GameController.Instance.PlayerProfile.Profile.LastUnlockLevel)
    //        {
    //            LevelsNoteList[i].Locked = false;
    //            LevelsNoteList[i - 1].Completed = true;
    //        }
    //    }
    //}
    public void LoadLevel(int level)
    {
        StartCoroutine(LoadLevelRoutine(level));
    }

    public void ResetLevel(int indexLevel, Level level)
    {
        SceneManager.LoadScene(indexLevel);
        SetLevel(level);
    }

    public void SetLevel(Level level)
    {
        _currentLevel = level;
        GameController.Instance.ScreenController.PushScreen<HUDScreen>();
        _currentLevel.PlayerCharacter.PlayerHealth.SetHealth(GameController.Instance.PlayerSession.MaxHealth);
        GameController.Instance.PlayerSession.Score = 0;
        GameController.Instance.PlayerSession.HUDScreen.UpdateHealthView(GameController.Instance.PlayerSession.MaxHealth);
        GameController.Instance.PlayerSession.HUDScreen.UpdateScoreText(0);
        Time.timeScale = 1f;
    }

    public void CompleteLevel(Level level)
    {
        level.CompletedLevel = true;

        //How does it? => nextLevel.LockedLevel = false;

        for (int i = 0; i < LevelsNoteList.Count; i++)
        {
            if (LevelsNoteList[i].LevelNumber.Equals(level.NumberLevel))
            {
                LevelsNoteList[i].Completed = true;
                if ((i + 1) < LevelsNoteList.Count)
                {
                    LevelsNoteList[i + 1].Locked = false;
                }
            }
        }
        GameController.Instance.PlayerProfile.Profile.LastUnlockLevel = level.NumberLevel;
        GameController.Instance.PlayerProfile.Save();
    }

    IEnumerator LoadLevelRoutine (int level)
    {
        AsyncOperation asyncProc = SceneManager.LoadSceneAsync(level);
        var loadScreen = GameController.Instance.ScreenController.PushScreen<LoadScreen>();
        while (!asyncProc.isDone)
        {
            loadScreen.SetProgress(asyncProc.progress);
            yield return null;
        }
        GameController.Instance.ScreenController.PushScreen<HUDScreen>();
        Time.timeScale = 1f;
    }
}
