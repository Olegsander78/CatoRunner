using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    public float JumpForce => _jumpForce;
    public Rigidbody2D Rig;  

    [SerializeField] private bool _isGrounded;

    private void FixedUpdate()
    { 
        if(Input.GetKey(KeyCode.Space))
        {
            if (_isGrounded)
            {
                Jump(JumpForce);
            }
        }
    }

    public void Jump(float jumpForce)
    {
        Rig.velocity += new Vector2(0f, jumpForce);
    }
    

    private void OnCollisionStay2D(Collision2D collision)
    {
        _isGrounded = true;

        //float dot = Vector2.Dot(collision.contacts[0].normal, Vector2.up);
        //if (dot > 0.5f)
        //{
        //    _isGrounded = true;
        //}
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded = false;
    }
}
