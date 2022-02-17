using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Left = 0,
    Right = 1
}

public class MoveObstacle : MonoBehaviour
{
    private const float LEFT_LENGTH_AUTODESTROY = -100f;
    private const float RIGHT_LENGTH_AUTODESTROY = 100f;
    private const float DOWN_LENGTH_AUTODESTROY = -30f;

    [Header("Points Parameters")]
    public Transform LeftPoint;
    public Transform RightPoint;
    public float SpeedPoints = 1.5f;
    //[SerializeField] private Transform _parentForPoints;

    [Header("Obstacle Parameters")]
    public float SpeedToLeft;
    public float SpeedToRight;

    public float StopTime;

    public Direction CurrentDirection;

    //private bool _isStopped;

    public Rigidbody2D ObstacleRig;

    public ObstacleCreator ObstacleCreator;

    private void Start()
    {
        ObstacleRig = GetComponent<Rigidbody2D>();
        //LeftPoint.SetParent(_parentForPoints, true);
        //RightPoint.SetParent(_parentForPoints, true);
        //LeftPoint.parent = null;
        //RightPoint.parent = null;
    }

    //private void Update()
    //{
    //   MoveTargetPoints();
    //}

    private void FixedUpdate()
    {
        StartMoveObstacle();         
    }

    private void MoveTargetPoints()
    {
        LeftPoint.transform.position -= SpeedPoints * Time.deltaTime * transform.right;
        RightPoint.transform.position -= SpeedPoints * Time.deltaTime * transform.right;

        if (LeftPoint.transform.position.x < LEFT_LENGTH_AUTODESTROY || LeftPoint.transform.position.x > RIGHT_LENGTH_AUTODESTROY || LeftPoint.transform.position.y < DOWN_LENGTH_AUTODESTROY)
        {
            Destroy(gameObject);
        }
        if (RightPoint.transform.position.x < LEFT_LENGTH_AUTODESTROY || RightPoint.transform.position.x > RIGHT_LENGTH_AUTODESTROY || RightPoint.transform.position.y < DOWN_LENGTH_AUTODESTROY)
        {
            Destroy(gameObject);
        }
    }


    public void StartMoveObstacle()
    {
        StartCoroutine(MoveObstacles());
    }
    private IEnumerator MoveObstacles()
    {
        if (LeftPoint != null && RightPoint != null)
        {
            if (CurrentDirection == Direction.Left)
            {
                ObstacleRig.velocity = -transform.right * SpeedToLeft;
                if (transform.localPosition.x < LeftPoint.localPosition.x)
                {
                    CurrentDirection = Direction.Right;
                    yield return new WaitForSeconds(StopTime);
                }
            }
            else
            {
                ObstacleRig.velocity = transform.right * SpeedToRight;
                if (transform.localPosition.x > RightPoint.localPosition.x)
                {
                    CurrentDirection = Direction.Left;
                    yield return new WaitForSeconds(StopTime);
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
