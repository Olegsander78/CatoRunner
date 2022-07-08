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
                var playerChar = collision.rigidbody.GetComponent<PlayerCharacter>();

                for (int i = 0; i < collision.contacts.Length; i++)
                {
                    if (collision.contacts[i].rigidbody.GetComponent<PlayerCharacter>() == playerChar)
                    {
                        float dot = Vector2.Dot(collision.contacts[i].normal, Vector2.up);

                        if (GetComponent<Enemy>().IsUnstumtable && dot < -0.2f)
                        {
                            collision.rigidbody.GetComponent<PlayerHealth>().TakeDamage(_damageToPlayer);
                        }
                        else if (!GetComponent<Enemy>().IsUnstumtable && (dot < 0.4f && dot >= -0.2f))
                        {
                            collision.rigidbody.GetComponent<PlayerHealth>().TakeDamage(_damageToPlayer);
                        }
                    }
                }




                //float dot = Vector2.Dot(collision.contacts[0].normal, Vector2.up);

                //if (GetComponent<Enemy>().IsUnstumtable && dot >= 0f)
                //{
                //    collision.rigidbody.GetComponent<PlayerHealth>().TakeDamage(_damageToPlayer);
                //}
                //else if (!GetComponent<Enemy>().IsUnstumtable && (dot < 0.4f && dot >= 0f))
                //{
                //    collision.rigidbody.GetComponent<PlayerHealth>().TakeDamage(_damageToPlayer);
                //}


                //if (!GetComponent<Enemy>().IsUnstumtable)
                //{
                //    float dot = Vector2.Dot(collision.contacts[0].normal, Vector2.down);

                //    if (dot < 0.4f)
                //    {
                //        collision.rigidbody.GetComponent<PlayerHealth>().TakeDamage(_damageToPlayer);
                //    }
                //}
                //else
                //{
                //    collision.rigidbody.GetComponent<PlayerHealth>().TakeDamage(_damageToPlayer);
                //}
            }
        }
    }
}
