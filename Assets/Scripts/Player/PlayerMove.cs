using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _jumpForce;    
    public float JumpForce => _jumpForce;

    [SerializeField] private float _jumpForceForTuch;

    public float JumpForceForTuch => _jumpForceForTuch;

    public Rigidbody2D Rig;

    public Animator PlayerAnimator;

    [SerializeField] private bool _isGrounded;
    [SerializeField] private float _groundPointRadius;
    [SerializeField] private Transform _groundPoint;
    [SerializeField] private LayerMask _whatIsGround;

    private float _nextTimeJump;

    public Action OnPlayerJump;

    private void Start()
    {
        Rig = GetComponentInParent<Rigidbody2D>();
    }

    public void TryJump(float jumpForce)
    {
        Debug.Log("Start jump");

        //if ((Grounded() || _isGrounded)&& Time.time > _nextTimeJump)
        if ((Grounded() || _isGrounded))
        {
            Debug.Log("Jump");
            Jump(jumpForce);

            PlayerAnimator.SetTrigger("Jump");
            _nextTimeJump = Time.time + 0.2f;
        }
    }

    public void Jump(float jumpForce)
    {        
        Rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        OnPlayerJump?.Invoke();
        //GameController.Instance.SoundController.PlaySound(SFX.SFXTypeEvents.JumpPlayer);
    }

    private bool Grounded()
    {
        return Physics2D.OverlapCircle(_groundPoint.position, _groundPointRadius, _whatIsGround);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (!enemy.IsUnstumtable)
            {
                float dot = Vector2.Dot(collision.contacts[0].normal, Vector2.down);

                if (dot > 0.4f)
                {
                    _isGrounded = true;
                }
            }
            else
            {
                _isGrounded = false;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded = false;
    }  
}
