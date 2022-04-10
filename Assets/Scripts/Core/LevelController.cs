using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Level _currentLevel;
    public Level CurrentLevel => _currentLevel;

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
