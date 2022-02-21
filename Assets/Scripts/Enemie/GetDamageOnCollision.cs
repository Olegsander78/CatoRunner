using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDamageOnCollision : MonoBehaviour
{
    [SerializeField] private int _damageToEnemy = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<PlayerCharacter>())
            {
                if (!GetComponent<Enemy>().IsUnstumtable)
                {
                    float dot = Vector2.Dot(collision.contacts[0].normal, Vector2.down);

                    if (dot > 0.4f)
                    {
                        GetComponent<Enemy>().GetDamage(_damageToEnemy);
                    }
                    //Debug.Log("dot = "+ dot);
                }
            }
        }
    }
}
