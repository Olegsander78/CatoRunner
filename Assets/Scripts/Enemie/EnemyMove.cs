using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyMove : MonoBehaviour
{
    public Transform TargetPosition;
    private Transform _startPosition;
    [SerializeField] private bool _movingToTargetPos;
    [SerializeField] private float _distanceToTargetPosition;

    public float MoveSpeed;

    public Rigidbody2D EnemyRig;

    private void Start()
    {
        //EnemyRig = GetComponent<Rigidbody2D>();
        //TargetPosition.parent = null;
        //_movingToTargetPos = true;

        //_distanceToTargetPosition = Mathf.Abs(transform.position.x - TargetPosition.position.x);
        _distanceToTargetPosition = Vector3.Distance(transform.position, TargetPosition.position);
        //Debug.LogWarning(_distanceToTargetPosition);
    }

    //private void Start()
    //{
    //    _startPosition = transform.position;
    //    _movingToTargetPos = true;
    //}

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


    //private void Update()
    //{
    //    if (_movingToTargetPos == true)
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, MoveSpeed * Time.deltaTime);
    //        if (transform.position == TargetPosition)
    //        {
    //            _movingToTargetPos = false;
    //        }
    //    }
    //    else
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position, _startPosition, MoveSpeed * Time.deltaTime);
    //        if (transform.position == _startPosition)
    //        {
    //            _movingToTargetPos = true;
    //        }
    //    }
    //}

    //private void FixedUpdate()
    //{
    //    if (EnemyRig)
    //    {
    //        if (_movingToTargetPos == true)
    //        {
    //            float timer = 0f;
    //            timer += Time.deltaTime;
    //            EnemyRig.velocity = -transform.right * MoveSpeed;
    //            float distance = EnemyRig.velocity.magnitude * timer;
    //            //Debug.Log(distance);
    //            if (distance > _distanceToTargetPosition)
    //            {
    //                _movingToTargetPos = false;
    //            }
    //        }
    //        else
    //        {
    //            float timer = 0f;
    //            timer += Time.deltaTime;
    //            EnemyRig.velocity = transform.right * MoveSpeed;
    //            float distance = EnemyRig.velocity.magnitude * timer;
    //            if (distance > _distanceToTargetPosition)
    //            {
    //                _movingToTargetPos = true;
    //            }
    //        }
    //    }
    //}

}
