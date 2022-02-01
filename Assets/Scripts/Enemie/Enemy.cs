using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const float LEFT_LENGTH_AUTODESTROY = -60f;
    private const float RIGHT_LENGTH_AUTODESTROY = 80f;
    private const float DOWN_LENGTH_AUTODESTROY = -20f;
    
    [SerializeField] private float _speedEnemy = 0.005f;
    [SerializeField] private int _healthEnemy = 1;
    [SerializeField] private int _scoreForEnemy = 100;

    public GameObject StampSound;

    public Animator Animator;


    private void Update()
    {
        transform.Translate(Vector2.left * _speedEnemy * Time.deltaTime);
        AutoDestroy();
    }

    public void GetDamage(int damageValue)
    {
        _healthEnemy -= damageValue;
        if (_healthEnemy <= 0)
        {
            DieEnemy(_scoreForEnemy);
        }
    }

    public void DieEnemy(int scoreForEnemy)
    {
        FindObjectOfType<HUDManager>().AddScore(scoreForEnemy);
        Animator.SetTrigger("Death");
        Destroy(gameObject, 1f);
    }    

    public void AutoDestroy()
    {
        if (transform.position.x < LEFT_LENGTH_AUTODESTROY || transform.position.x > RIGHT_LENGTH_AUTODESTROY || transform.position.y < DOWN_LENGTH_AUTODESTROY)
        {
            Destroy(gameObject);
        }
    }
}
