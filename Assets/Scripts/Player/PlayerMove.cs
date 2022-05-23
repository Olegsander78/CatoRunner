using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _jumpForce;    
    public float JumpForce => _jumpForce;

    public Rigidbody2D Rig;  

    [SerializeField] private bool _isGrounded;
    [SerializeField] private float _groundPointRadius;
    [SerializeField] private Transform _groundPoint;
    [SerializeField] private LayerMask _layerMaskGround;

    private void Start()
    {
        Rig = GetComponentInParent<Rigidbody2D>();
    }    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Grounded() || _isGrounded)
            {
                Jump(JumpForce);
            }
        }
    }

    public void Jump(float jumpForce)
    {        
        Rig.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        GameController.Instance.SoundController.PlaySound(SFX.SFXTypeEvents.JumpPlayer);
    }

    private bool Grounded()
    {
        return Physics2D.OverlapCircle(_groundPoint.position, _groundPointRadius, _layerMaskGround);
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
