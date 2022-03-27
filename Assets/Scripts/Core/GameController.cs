using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set;}
    [SerializeField] private LevelController _levelController;
    [SerializeField] private PlayerProfile _playerProfile;
    [SerializeField] private ScreenController _screenController;
    public LevelController LevelController => _levelController;
    public PlayerProfile PlayerProfile => _playerProfile;
    public ScreenController ScreenController => _screenController;


    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
        //LoadLevel(1);
    }

    public void LoadLevel(int level)
    {
        LevelController.LoadLevel(level);
    }

}
