using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private const float DURATION_INVUL_AFTER_DAMAGE = 3f;

    [SerializeField] private int _currentPlayerHealth;
    [SerializeField] private bool _isInvulnerability = false;
    [SerializeField] private float _delayDestroyPlayer = 1.5f;
    [SerializeField] private float _speedBeforeGameOver = 0.3f;

    [SerializeField] private Animator PlayerAnimator;

    public bool CheatMode = false;

    public UnityEvent EventOnTakeDamage;

    private void Start()
    {
        _currentPlayerHealth = GameController.Instance.PlayerProfile.MaxHealth;
        GameController.Instance.PlayerProfile.HUDScreen.UpdateHealthView(_currentPlayerHealth);
    }

    public void AddHealth(int amount)
    {
        _currentPlayerHealth += amount;

        if (_currentPlayerHealth > GameController.Instance.PlayerProfile.MaxHealth)
        {
            _currentPlayerHealth = GameController.Instance.PlayerProfile.MaxHealth;
        }
        GameController.Instance.PlayerProfile.HUDScreen.UpdateHealthView(_currentPlayerHealth);
    }

    public void SetHealth(int amount)
    {
        _currentPlayerHealth = amount;
        GameController.Instance.PlayerProfile.HUDScreen.UpdateHealthView(_currentPlayerHealth);
    }

    public void TakeDamage(int damage)
    {
        if (!_isInvulnerability)
        {
            _currentPlayerHealth -= damage;
            GameController.Instance.PlayerProfile.HUDScreen.UpdateHealthView(_currentPlayerHealth);
            GameController.Instance.SoundController.PlaySound(SFX.SFXTypeEvents.DamagePlayer);
            if (_currentPlayerHealth <= 0 && !CheatMode)
            {
                _currentPlayerHealth = 0;
                GameController.Instance.PlayerProfile.HUDScreen.UpdateHealthView(_currentPlayerHealth);

                GameController.Instance.LevelController.CurrentLevel.ChangeSpeedLevel(_speedBeforeGameOver);
                PlayerAnimator.SetTrigger("Death");                

                Invoke("GameOver", _delayDestroyPlayer);
            }

            PlayerAnimator.SetTrigger("HitPlayer");

            _isInvulnerability = true;

            StartInvulnerable(DURATION_INVUL_AFTER_DAMAGE);            

            EventOnTakeDamage.Invoke();
        }
    }
    public void StartInvulnerable(float duration)
    {
        StartCoroutine(InvulnerableState(duration));
    }
    
    public IEnumerator InvulnerableState(float duration)
    {
        _isInvulnerability = true;
        yield return new WaitForSeconds(duration);
        _isInvulnerability = false;
    }

    public void GameOver()
    {
        Destroy(gameObject);

        Time.timeScale = 0f;
        GameController.Instance.ScreenController.PushScreen<GameOverScreen>();
        GameController.Instance.SoundController.StopBGMusic();
        GameController.Instance.SoundController.PlaySound(SFX.SFXTypeEvents.GameOver);
    }

    //public IEnumerator GameOverRoutina(float duration)
    //{
    //    PlayerAnimator.SetTrigger("Death");
    //    yield return new WaitForSeconds(duration);
    //}
}
