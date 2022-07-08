using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{       
    [SerializeField] private int _healthEnemy = 1;    
    [SerializeField] private int _scorePerEnemy = 100;
    [SerializeField] private bool _IsUnstomtable = false;
    public bool IsUnstumtable { get => _IsUnstomtable; set => _IsUnstomtable = value; }

    [SerializeField] private SFX.SFXTypeCreatures _screamEnemyOnDamage;
    public SFX.SFXTypeCreatures ScreamEnemyOnDamage => _screamEnemyOnDamage;

    [SerializeField] private SFX.SFXTypeCreatures _screamEnemyOnDie;
    public SFX.SFXTypeCreatures ScreamEnemyOnDie => _screamEnemyOnDie;    

    public Animator Animator;

    public void GetDamage(int damageValue)
    {
        _healthEnemy -= damageValue;

        //GameController.Instance.SoundController.PlaySound(ScreamEnemyOnDamage);

        if (_healthEnemy <= 0)
        {
            DieEnemy(_scorePerEnemy);
        }
    }

    public void DieEnemy(int scorePerEnemy)
    {
        if (TryGetComponent(out Collider2D collider))
        {
            collider.enabled = false;
        }
        else if (GetComponentInChildren<Collider2D>() != null)
        {
            GetComponentInChildren<Collider2D>().enabled = false;
        }
        //Extra scores for defeat Enemy
        GameController.Instance.PlayerSession.AddScore(scorePerEnemy);
        GameController.Instance.EventBus.OnCoinCollected(scorePerEnemy);

        GameController.Instance.SoundController.PlaySound(ScreamEnemyOnDie);
        GameController.Instance.EventBus.OnEnemydefeated(this);        
        
        Animator.SetTrigger("Death");

        Destroy(gameObject, 1f);
    }
}
