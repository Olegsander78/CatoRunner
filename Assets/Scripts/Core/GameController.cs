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
    public ScreenController ScreenController { get => _screenController; set => value = _screenController; }
    public SoundController SoundController { get => _soundController; set => value = _soundController; }
    public EventBus EventBus => _eventBus;

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

        DontDestroyOnLoad(this);
        DontDestroyOnLoad(Instance.ScreenController);
        //DontDestroyOnLoad(Instance._soundController);

        _eventBus = new EventBus();
    }

    public void LoadLevel(int level)
    {
        //if (Instance.SoundController != null) Destroy(SoundController);
        //if (Instance.ScreenController != null) Destroy(ScreenController);
        LevelController.LoadLevel(level);
    }

    public void ResetLevel(int indexLevel, Level level)
    {
        LevelController.ResetLevel(indexLevel, level);
    }
}
