using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //public float JumpForce;
    public float JumpSpeed;
    public Rigidbody2D Rig;  

    [SerializeField] private bool _isGrounded;

    private void FixedUpdate()
    {
        //if (Input.GetKey(KeyCode.Space) && IsGrounded())
        //{
        //    Rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        //}

        if (Input.GetKey(KeyCode.Space))
        {
            if (_isGrounded)
            {
                // Rig.velocity += new Vector2(0f, JumpSpeed);
                Rig.AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);
            }
        }

    }
    

    private void OnCollisionStay2D(Collision2D collision)
    {
        float dot = Vector2.Dot(collision.contacts[0].normal, Vector2.up);
        if (dot > 0.5f)
        {
            _isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded = false;
    }


    //Проверка на приземление через Raycast
    //bool IsGrounded()
    //{
    //    RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0f, -1f, 0f),
    //        Vector2.down, 0.2f);
    //    return hit.collider != CompareTag("Ground");
    //}
}
