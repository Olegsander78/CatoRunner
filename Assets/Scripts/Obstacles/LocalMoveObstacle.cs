using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LocalMoveObstacle : MonoBehaviour
{
    public enum LocalDirection
    {
        Left = 0,
        Right = 1
    }

    [Header("Points Parameters")]
    public Transform LeftPoint;
    public Transform RightPoint;

    [Header("Obstacle Parameters")]
    public float SpeedToLeft;
    public float SpeedToRight;

    public float StopTime;

    public LocalDirection CurrentDirection;

    public Rigidbody2D ObstacleRig;

    private void Start()
    {
        ObstacleRig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float speedUpLevelModif = GameController.Instance.LevelController.CurrentLevel.SpeedLevel
            / GameController.Instance.LevelController.CurrentLevel.StartSpeedLevel;
        StartMoveObstacle(speedUpLevelModif);
    }

    public void StartMoveObstacle(float speedModif)
    {
        StartCoroutine(MoveObstacles(speedModif));
    }
    private IEnumerator MoveObstacles(float speedModif)
    {
        if (LeftPoint != null && RightPoint != null)
        {
            if (CurrentDirection == LocalDirection.Left)
            {
                ObstacleRig.velocity = -transform.right * SpeedToLeft * speedModif;
                if (transform.position.x < LeftPoint.position.x)
                {
                    CurrentDirection = LocalDirection.Right;
                    yield return new WaitForSeconds(StopTime);
                }
            }
            else
            {
                ObstacleRig.velocity = transform.right * SpeedToRight * speedModif;
                if (transform.position.x > RightPoint.position.x)
                {
                    CurrentDirection = LocalDirection.Left;
                    yield return new WaitForSeconds(StopTime);
                }
            }
        }
    }
}
