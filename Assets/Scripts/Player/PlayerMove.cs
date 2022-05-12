using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _jumpForce;    
    public float JumpForce => _jumpForce;

    [SerializeField] private Vector2 _playerStartPoint;

    public Rigidbody2D Rig;  

    [SerializeField] private bool _isGrounded;

    private void Start()
    {
        Rig = GetComponentInParent<Rigidbody2D>();
        _playerStartPoint = transform.position;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && _isGrounded)
        {
            Jump(JumpForce);
        }

        CheckStartPoint();
    }

    public void Jump(float jumpForce)
    {
        Rig.velocity += new Vector2(0f, jumpForce);
        GameController.Instance.SoundController.PlaySound(SFX.SFXTypeEvents.JumpPlayer);
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        _isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded = false;
    }

    public void CheckStartPoint()
    {
        if (transform.position.x != _playerStartPoint.x)
        {
            //Rig.MovePosition(_playerStartPoint * Time.fixedDeltaTime * 10f);
            //Rig.MovePosition(Vector2.Lerp(transform.position, _playerStartPoint, 1f));
            //Rig.transform.position = Vector2.Lerp(transform.position, _playerStartPoint, 1f);
        }
    }
}
