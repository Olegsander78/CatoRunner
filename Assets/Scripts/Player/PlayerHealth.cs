using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private const int MAX_PLAYER_HEALTH = 5;
    private const float DURATION_INVUL_AFTER_DAMAGE = 3f;

    [SerializeField] private int _currentPlayerHealth;
    [SerializeField] private bool _isInvulnerability = false;
 
    public HUDManager HUDview;

    public UnityEvent EventOnTakeDamage;

    private void Start()
    {
        _currentPlayerHealth = MAX_PLAYER_HEALTH;
        HUDview.UpdateHealthView(_currentPlayerHealth);
    }    

    public void AddHealth(int amount)
    {
        _currentPlayerHealth += amount;

        if (_currentPlayerHealth > MAX_PLAYER_HEALTH)
        {
            _currentPlayerHealth = MAX_PLAYER_HEALTH;
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
            StartInvulnerable();
            HUDview.UpdateHealthView(_currentPlayerHealth);
            EventOnTakeDamage.Invoke();
        }
    }
    public void StartInvulnerable()
    {
        StartCoroutine(InvulnerableState(DURATION_INVUL_AFTER_DAMAGE));
    }
    
    public IEnumerator InvulnerableState(float duration)
    {
        _isInvulnerability = true;
        yield return new WaitForSeconds(duration);
        _isInvulnerability = false;
    }

    public void GameOver()
    {
        Debug.LogWarning("Player Die!!!");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }  

}
