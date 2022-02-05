using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour
{
    private const int MAX_PLAYER_HEALTH = 3;
    private const float DURATION_INVUL_AFTER_DAMAGE = 3f;
    [SerializeField] private int _currentPlayerHealth = 3;
    [SerializeField] private bool _isInvulnerability = false;
    [SerializeField] private int _score = 0;
 
    public HUDManager HUDview;

    private void Start()
    {
        _currentPlayerHealth = MAX_PLAYER_HEALTH;
        HUDview.UpdateScoreText(_score);
        HUDview.UpdateHealthView(_currentPlayerHealth);
    }
    
    public void AddScore(int amount)
    {
        _score += amount;
        HUDview.UpdateScoreText(_score);
    }

    public void AddHealth(int amount)
    {
        if (_currentPlayerHealth < MAX_PLAYER_HEALTH)
        {
            _currentPlayerHealth += amount;
        }
        HUDview.UpdateHealthView(_currentPlayerHealth);
    }

    public void TakeDamage(int damage)
    {
        if (!_isInvulnerability)
        {
            _currentPlayerHealth -= damage;
            if (_currentPlayerHealth <= 0)
            {
                _currentPlayerHealth = 0;
                GameOver();
            }
            _isInvulnerability = true;
            Invoke("StopInvulnerability", DURATION_INVUL_AFTER_DAMAGE);
            //AddInvulnerability(DURATION_INVUL_AFTER_DAMAGE);
        }
        HUDview.UpdateHealthView(_currentPlayerHealth);
    }

    private void StopInvulnerability()
    {
        _isInvulnerability = false;
    }

    //ToDo Сделать вввиде корутины включение неуязвимости при подборе айтема Неузявимость.
    
    //public void AddInvulnerability(float duration)
    //{
    //    _isInvulnerability = true;
    //    float timer = Time.time;
    //    if (timer > duration)
    //    {
    //        _isInvulnerability = false;
    //    }
    //}



    //Сделать ускорение уровня  2х при подборе айтема Ускорение
    public void AddSpeedUp()
    {

    }

    public void GameOver()
    {
        Debug.LogWarning("Player Die!!!");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }  

}
