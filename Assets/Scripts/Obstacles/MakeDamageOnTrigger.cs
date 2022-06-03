using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnTrigger : MonoBehaviour
{
    private const float SERIOUS_DAMAGE = 50f;

    [SerializeField] private int _damageToPlayer = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out var playerHealth))
        {
            if (_damageToPlayer > SERIOUS_DAMAGE)
            {
                playerHealth.GameOver();
            }
            playerHealth.TakeDamage(_damageToPlayer);
        }
    }
}
