using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour
{   
 
    [SerializeField] private PlayerHealth _playerHealth;
    public PlayerHealth PlayerHealth => _playerHealth;  


    //—делать PowerUp, игрок увеличиваетс€ в 2 раза и становитьс€ неу€звимым
    public void AddPowerUp()
    {

    }

    //—делать ускорение уровн€  2х при подборе айтема ”скорение
    public void AddSpeedUp()
    {

    }
}
