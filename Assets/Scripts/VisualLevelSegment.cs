using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualLevelSegment : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    public Rigidbody2D RigidbodyVisualLevel => _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
}
