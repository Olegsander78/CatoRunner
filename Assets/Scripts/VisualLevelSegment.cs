using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualLevelSegment : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    public Rigidbody2D Rigidbody => _rb;

    [SerializeField] private float _velocityMultiply;
    public float VelocityMultiply => _velocityMultiply;
}
