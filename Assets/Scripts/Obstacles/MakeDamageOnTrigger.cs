using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] private int _damageToPlayer = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody)
        {
            if (collision.attachedRigidbody.GetComponent<PlayerHealth>())
            {
                collision.attachedRigidbody.GetComponent<PlayerHealth>().TakeDamage(_damageToPlayer);
            }
        }
    }
}
