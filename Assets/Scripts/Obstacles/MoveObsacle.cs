using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Left = 0,
    Right = 1
}

public class MoveObsacle : MonoBehaviour
{
    public Transform LeftTarget;
    public Transform RightTarget;
    public float SpeedTarget = 1.5f;
    [SerializeField] private Transform _parentForTarget;

    public float LeftSpeed;
    public float RightSpeed;

    public float StopTime;

    public Direction CurrentDirection;

    private bool _isStopped;

    public Rigidbody2D ObstacleRig;

    private void Start()
    {
        ObstacleRig = GetComponent<Rigidbody2D>();
        LeftTarget.SetParent(_parentForTarget, true);
        RightTarget.SetParent(_parentForTarget, true);
    }

    private void Update()
    {
        MoveTargetPoints();
    }

    private void FixedUpdate()
    {
        StartMoveObstacle();         
    }

    private void MoveTargetPoints()
    {
        LeftTarget.transform.position += SpeedTarget * Time.deltaTime * transform.right;
        RightTarget.transform.position += SpeedTarget * Time.deltaTime * transform.right;
    }


    public void StartMoveObstacle()
    {
        StartCoroutine(MoveObstacle());
    }
    private IEnumerator MoveObstacle()
    {
        if (CurrentDirection == Direction.Left)
        {
            ObstacleRig.velocity = -transform.right * LeftSpeed;
            if (transform.position.x < LeftTarget.position.x)
            {
                CurrentDirection = Direction.Right;
                yield return new WaitForSeconds(1f);
            }
        }
        else
        {
            ObstacleRig.velocity = transform.right * RightSpeed;
            if (transform.position.x > RightTarget.position.x)
            {
                CurrentDirection = Direction.Left;
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
