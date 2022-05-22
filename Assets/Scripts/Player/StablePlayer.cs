using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StablePlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rg;
    [SerializeField] private float _xPosition= -2f;
    [SerializeField] private float _velocityMuliply = 1f;
    

    private void FixedUpdate()
    {
        Vector2 velocity = _rg.velocity;
        velocity.x = (_xPosition - transform.position.x) * _velocityMuliply;
        _rg.velocity = velocity;
    }
}
