using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDamageOnCollision : MonoBehaviour
{
    private const float JUMP_MULTIPLY = 2.5f;

    [SerializeField] private int _damageToEnemy = 1;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<PlayerCharacter>())
            {
                var playerChar = collision.rigidbody.GetComponent<PlayerCharacter>();

                if (!GetComponent<Enemy>().IsUnstumtable)
                {
                    float dot = Vector2.Dot(collision.contacts[0].normal, Vector2.down);

                    if (dot > 0.4f)
                    {
                        GetComponent<Enemy>().GetDamage(_damageToEnemy);
                        playerChar.PlayerMove.Jump(playerChar.PlayerMove.JumpForce * JUMP_MULTIPLY);
                    }
                    //Debug.Log("dot = "+ dot);
                }
            }
        }
    }
}
