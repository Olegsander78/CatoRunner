using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    [System.Serializable]
    public class LevelsNote
    {
        public int LevelNumber;
        public bool Completed;
        public bool Locked;

        public LevelsNote(int id, bool completed, bool locked)
        {
            LevelNumber = id;
            Completed = completed;
            Locked = locked;
        }
    }

    [SerializeField] private List<LevelsNote> _levelsNoteList;
    public List<LevelsNote> LevelsNoteList { get => _levelsNoteList; set => _levelsNoteList = value; }

    [SerializeField] private Level _currentLevel;
    public Level CurrentLevel => _currentLevel;

    

    private void Awake()
    {
        LevelsNoteList = new List<LevelsNote>
        {
            new LevelsNote(1,false,false),
            new LevelsNote(2,false,true),
            new LevelsNote(3,false,true),
            new LevelsNote(4,false,true),
            new LevelsNote(5,false,true)
        };
    }

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
        _currentLevel.PlayerCharacter.PlayerHealth.SetHealth(GameController.Instance.PlayerProfile.MaxHealth);
        GameController.Instance.PlayerProfile.Score = 0;
        GameController.Instance.PlayerProfile.HUDScreen.UpdateHealthView(GameController.Instance.PlayerProfile.MaxHealth);
        GameController.Instance.PlayerProfile.HUDScreen.UpdateScoreText(0);
        Time.timeScale = 1f;
    }

    public void CompleteLevel(Level level)
    {
        level.CompletedLevel = true;
        //Не могу сообразить как подтянуть следующий уровень..
        //nextLevel.LockedLevel = false;

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
    }

    IEnumerator LoadLevelRoutine (int level)
    {
        AsyncOperation asyncProc = SceneManager.LoadSceneAsync(level);
        var loadScreen= GameController.Instance.ScreenController.PushScreen<LoadScreen>();
        while (!asyncProc.isDone)
        {
            loadScreen.SetProgress(asyncProc.progress);
            yield return null;
        }
        GameController.Instance.ScreenController.PushScreen<HUDScreen>();
        Time.timeScale = 1f;
    }
}
