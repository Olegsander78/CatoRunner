using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set;}

    [SerializeField] private LevelController _levelController;
    [SerializeField] private PlayerSession _playerSession;

    [SerializeField] private ScreenController _screenController;
    [SerializeField] private SoundController _soundController;
    [SerializeField] private PlayerProfile _playerProfile;    
    public PlayerProfile PlayerProfile => _playerProfile;

    private EventBus _eventBus;
    public LevelController LevelController => _levelController;
    public PlayerSession PlayerSession => _playerSession;
    public ScreenController ScreenController { get => _screenController; set => value = _screenController; }
    public SoundController SoundController { get => _soundController; set => value = _soundController; }
    public EventBus EventBus => _eventBus;

    // For Unity ADS
    //[Header("Unity ADS")]
    //[SerializeField] private AdManager _adManager;

    //public AdManager AdManager => _adManager;

    //For Yandex Game ADS
    [Header("Yandex ADS")]
    [SerializeField] private AdYAManager _adYAManager;
    public AdYAManager AdYAManager => _adYAManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        _eventBus = new EventBus();
    }

    public void LoadLevel(int level)
    {
        LevelController.LoadLevel(level);
    }

    public void ResetLevel(int indexLevel, Level level)
    {
        LevelController.ResetLevel(indexLevel, level);
    }
}
