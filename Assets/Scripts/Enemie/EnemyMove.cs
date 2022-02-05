using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Vector3 TargetPosition;
    private Vector3 _startPosition;

    public float MoveSpeed;
    private bool _movingToTargetPos;

    private void Start()
    {
        _startPosition = transform.position;
        _movingToTargetPos = true;
    }

    private void Update()
    {
        if (_movingToTargetPos == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition, MoveSpeed * Time.deltaTime);
            if (transform.position == TargetPosition)
            {
                _movingToTargetPos = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _startPosition, MoveSpeed * Time.deltaTime);
            if (transform.position == _startPosition)
            {
                _movingToTargetPos = true;
            }
        }
    }
}
