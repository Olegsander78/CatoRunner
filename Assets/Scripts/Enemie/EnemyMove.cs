using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

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

    /*private IEnumerator GhostBlinkRoutine()
    {
        var wait = new WaitForSeconds(2.0f);
        while (true)
        {
            yield return wait;
            MoveToGhostWorld();
            yield return wait;
            MoveToRealWorld();
        }
    }

    private void MoveToGhostWorld()
    {
        isInGhostWorld = true;
    }

    private void MoveToRealWorld()
    {
        isInGhostWorld = false;
    }  
    
    
    private float _nextMoveToAnotherWorldTime = 0f;
    private bool isInGhostWorld = false;

    void Update()
    {
        if (_nextMoveToAnotherWorldTime > Time.time)
            return;
        if (isInGhostWorld)
            MoveToRealWorld();
        else 
            MoveToGhostWorld();
        _nextMoveToAnotherWorldTime = Time.time + 2.0f;
    }*/


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
