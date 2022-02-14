using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private int _damageToPlayer = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<PlayerHealth>())
            {
                if (!GetComponent<Enemy>().IsUnstumtable)
                {
                    float dot = Vector2.Dot(collision.contacts[0].normal, Vector2.down);

                    if (dot < 0.4f)
                    {
                        collision.rigidbody.GetComponent<PlayerHealth>().TakeDamage(_damageToPlayer);
                    }
                }
                else
                {
                    collision.rigidbody.GetComponent<PlayerHealth>().TakeDamage(_damageToPlayer);
                }
            }
        }
    }
}
