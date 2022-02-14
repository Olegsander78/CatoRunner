using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{    
    [SerializeField] private float _speedEnemy = 0.005f;
    [SerializeField] private int _healthEnemy = 1;    
    [SerializeField] private int _scorePerEnemy = 100;
    [SerializeField] private bool _IsUnstumtable = false;

    public GameObject StampSound;

    public Animator Animator;

    public bool IsUnstumtable { get => _IsUnstumtable; set => _IsUnstumtable = value; }

    private void Update()
    {
        transform.Translate(Vector2.left * _speedEnemy * Time.deltaTime);
    }

    public void GetDamage(int damageValue)
    {
        _healthEnemy -= damageValue;
        if (_healthEnemy <= 0)
        {
            DieEnemy(_scorePerEnemy);
        }
    }

    public void DieEnemy(int scorePerEnemy)
    {
        FindObjectOfType<PlayerCharacter>().AddScore(scorePerEnemy);
        Animator.SetTrigger("Death");
        Destroy(gameObject, 0.5f);
    }  
}
