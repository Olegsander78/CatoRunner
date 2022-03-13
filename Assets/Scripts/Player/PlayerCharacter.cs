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


    //������� PowerUp, ����� ������������� � 2 ���� � ����������� ����������
    public void AddPowerUp()
    {

    }

    //������� ��������� ������  2� ��� ������� ������ ���������
    public void AddSpeedUp()
    {

    }
}
