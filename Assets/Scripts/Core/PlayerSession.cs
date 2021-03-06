using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSession : MonoBehaviour
{
    public int MaxHealth = 5;
    public int Score = 0;
 
    public HUDScreen HUDScreen;

    public PlayerCharacter PlayerCharacter;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {       
        HUDScreen.UpdateScoreText(Score);
    }

    public void AddScore(int amount)
    {
        Score += amount;
        HUDScreen.UpdateScoreText(Score);
    }
}
