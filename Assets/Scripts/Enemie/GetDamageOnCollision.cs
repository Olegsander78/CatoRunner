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
                var playerChar = collision.rigidbody.GetComponent<PlayerCharacter>();

                for (int i = 0; i < collision.contacts.Length; i++)
                {
                    if (collision.contacts[i].rigidbody.GetComponent<PlayerCharacter>() == playerChar)
                    {
                        float dot = Vector2.Dot(collision.contacts[i].normal, Vector2.up);

                        if (GetComponent<Enemy>().IsUnstumtable && dot > 0.3f)
                        {
                            GetComponent<Enemy>().GetDamage(_damageToEnemy);
                        } 
                        else if (!GetComponent<Enemy>().IsUnstumtable && (dot > 0.3f || dot < -0.3f))
                        {
                            GetComponent<Enemy>().GetDamage(_damageToEnemy);
                        }
                    }
                }                


                //if (!GetComponent<Enemy>().IsUnstumtable)
                //{
                //    float dot = Vector2.Dot(collision.contacts[0].normal, Vector2.down);

                //    if (dot > 0.4f)
                //    {
                //        GetComponent<Enemy>().GetDamage(_damageToEnemy);
                //    }
                //}
            }
        }
    }
}
