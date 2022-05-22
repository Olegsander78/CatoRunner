using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualLevelSegment : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    public Transform Transform { get => _transform; set => _transform = value; }

    [SerializeField] private Rigidbody2D _rb;
    public Rigidbody2D Rigidbody => _rb;

    [SerializeField] private float _velocityMultiply;
    public float VelocityMultiply => _velocityMultiply;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody2D>();
    }
}
