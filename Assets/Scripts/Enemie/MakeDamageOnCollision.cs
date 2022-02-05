using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private int _damageToPlayer = 1;
    [SerializeField] private bool _IsUnstumtable = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<PlayerCharacter>())
            {
                if (!_IsUnstumtable)
                {
                    float dot = Vector2.Dot(collision.contacts[0].normal, Vector2.up);

                    if (dot < 0.5f)
                    {
                        collision.rigidbody.GetComponent<PlayerCharacter>().TakeDamage(_damageToPlayer);
                    }
                }
                else
                {
                    collision.rigidbody.GetComponent<PlayerCharacter>().TakeDamage(_damageToPlayer);
                }
                //ToDo Оттолкнуть игрока или добавить блинк?
            }
        }
    }
}
