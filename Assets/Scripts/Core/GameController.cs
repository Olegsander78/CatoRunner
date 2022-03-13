using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set;}
    [SerializeField] private LevelController _levelController;
    [SerializeField] private PlayerProfile _playerProfile;
    public LevelController LevelController => _levelController;
    public PlayerProfile PlayerProfile => _playerProfile;


    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
        LoadLevel(1);

    }

    public void LoadLevel(int level)
    {
        LevelController.LoadLevel(level);
    }

}
