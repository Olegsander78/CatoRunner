using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set;}
    [SerializeField] private LevelController _levelController;
    [SerializeField] private PlayerProfile _playerProfile;
    [SerializeField] private ScreenController _screenController;
    [SerializeField] private SoundController _soundController;

    private EventBus _eventBus;
    public LevelController LevelController => _levelController;
    public PlayerProfile PlayerProfile => _playerProfile;
    public ScreenController ScreenController => _screenController;
    public SoundController SoundController => _soundController;
    public EventBus EventBus => _eventBus;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }

        _eventBus = new EventBus();
    }

    public void LoadLevel(int level) => LevelController.LoadLevel(level);

    public void ResetLevel(int indexLevel, Level level) => LevelController.ResetLevel(indexLevel, level);

}
