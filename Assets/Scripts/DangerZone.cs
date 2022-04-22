using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    //[SerializeField] private float _timeToDeathPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out PlayerHealth PlayerHealth))
        {
            PlayerHealth.TakeDamage(100);
        }
    }
}
