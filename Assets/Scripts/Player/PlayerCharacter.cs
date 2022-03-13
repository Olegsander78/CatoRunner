using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour
{   
    [SerializeField] private int _score = 0;
 
    public HUDManager HUDview;

    [SerializeField] private PlayerHealth _playerHealth;
    public PlayerHealth PlayerHealth => _playerHealth;

    private void Start()
    {       
        HUDview.UpdateScoreText(_score);
    }

    public void AddScore(int amount)
    {
        _score += amount;
        HUDview.UpdateScoreText(_score);
    }


    //—делать PowerUp, игрок увеличиваетс€ в 2 раза и становитьс€ неу€звимым
    public void AddPowerUp()
    {

    }

    //—делать ускорение уровн€  2х при подборе айтема ”скорение
    public void AddSpeedUp()
    {

    }
}
