using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] private float _speedEnemy = 0.005f;

    public GameObject StampSound;


    private void Update()
    {
        transform.Translate(Vector2.left * _speedEnemy);
        AutoDestroy();
    }


    public void AutoDestroy()
    {
        if (transform.position.x < -50f || transform.position.x > 60f)
        {
            Destroy(gameObject);
        }
    }
}
