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
        SceneManager.LoadScene(level);
    }

    public void SetLevel(Level level)
    {
        _currentLevel = level;
        _currentLevel.PlayerCharacter.PlayerHealth.SetHealth(GameController.Instance.PlayerProfile.MaxHealth);
    }
}
