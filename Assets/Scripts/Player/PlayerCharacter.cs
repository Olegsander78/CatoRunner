using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour
{   
 
    [SerializeField] private PlayerHealth _playerHealth;
    public PlayerHealth PlayerHealth => _playerHealth;  


    //������� PowerUp, ����� ������������� � 2 ���� � ����������� ����������
    public void AddPowerUp()
    {

    }

    //������� ��������� ������  2� ��� ������� ������ ���������
    public void AddSpeedUp()
    {

    }
}
