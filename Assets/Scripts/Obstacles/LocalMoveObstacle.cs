using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LocalMoveObstacle : MonoBehaviour
{
    public enum MovingPoints
    {
        First = 0,
        Second = 1
    }
    public enum LocalDirection
    {
        Vertical = 0,
        Horizontal = 1,
        Diagonal = 3
    }

    [Header("Points Parameters")]
    public Transform FirstPoint;
    public Transform SecondPoint;

    [Header("Obstacle Parameters")]
    public float SpeedToLeft;
    public float SpeedToRight;

    public float StopTime;

    public MovingPoints CurrentPoint = MovingPoints.First;
    public LocalDirection DirectionObstacle;

    public Rigidbody2D ObstacleRig;

    private void Start()
    {
        ObstacleRig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float speedUpLevelModif = GameController.Instance.LevelController.CurrentLevel.SpeedLevel
            / GameController.Instance.LevelController.CurrentLevel.StartSpeedLevel;
       
        if(DirectionObstacle == LocalDirection.Horizontal)
        {
            StartMoveObstacleHorizontal(speedUpLevelModif);
        }else if(DirectionObstacle == LocalDirection.Vertical)
        {
            StartMoveObstacleVertical(speedUpLevelModif);
        }else if(DirectionObstacle == LocalDirection.Diagonal)
        {
            StartMoveObstacleVertical(speedUpLevelModif);
        }        
    }

    public void StartMoveObstacleHorizontal(float speedModif)
    {
        StartCoroutine(MoveObstaclesHorizontal(speedModif));
    }
    private IEnumerator MoveObstaclesHorizontal(float speedModif)
    {
        if (FirstPoint != null && SecondPoint != null)
        {
            if (CurrentPoint == MovingPoints.First)
            {
                ObstacleRig.velocity = -transform.right * SpeedToLeft * speedModif;
                if (transform.position.x < FirstPoint.position.x)
                {
                    CurrentPoint = MovingPoints.Second;
                    yield return new WaitForSeconds(StopTime);
                }
            }
            else
            {
                ObstacleRig.velocity = transform.right * SpeedToRight * speedModif;
                if (transform.position.x > SecondPoint.position.x)
                {
                    CurrentPoint = MovingPoints.First;
                    yield return new WaitForSeconds(StopTime);
                }
            }
        }
    }
    public void StartMoveObstacleVertical(float speedModif)
    {
        StartCoroutine(MoveObstaclesVertical(speedModif));
    }

    private IEnumerator MoveObstaclesVertical(float speedModif)
    {
        if (FirstPoint != null && SecondPoint != null)
        {
            if (CurrentPoint == MovingPoints.First)
            {
                ObstacleRig.transform.position += transform.up * SpeedToLeft * speedModif * Time.deltaTime;
                //ObstacleRig.velocity = new Vector2(SpeedToLeft * speedModif, ObstacleRig.velocity.y);
                if (transform.position.y > SecondPoint.position.y)
                {
                    CurrentPoint = MovingPoints.Second;
                    yield return new WaitForSeconds(StopTime);
                }
            }
            else
            {
                ObstacleRig.transform.position -= transform.up * SpeedToRight * speedModif * Time.deltaTime;
                //ObstacleRig.velocity = new Vector2(SpeedToRight * speedModif, ObstacleRig.velocity.y);
                if (transform.position.y < FirstPoint.position.y)
                {
                    CurrentPoint = MovingPoints.First;
                    yield return new WaitForSeconds(StopTime);
                }
            }
        }
    }

    public void StartMoveObstacleDiagonal(float speedModif)
    {
        StartCoroutine(MoveObstaclesDiagonal(speedModif));
    }

    private IEnumerator MoveObstaclesDiagonal(float speedModif)
    {
        if (FirstPoint != null && SecondPoint != null)
        {
            if (CurrentPoint == MovingPoints.First)
            {
                ObstacleRig.velocity = -transform.position * SpeedToLeft * speedModif;
                //ObstacleRig.velocity = new Vector2(SpeedToLeft * speedModif, ObstacleRig.velocity.y);
                if (transform.position == FirstPoint.position)
                {
                    CurrentPoint = MovingPoints.Second;
                    yield return new WaitForSeconds(StopTime);
                }
            }
            else
            {
                ObstacleRig.velocity = transform.position * SpeedToRight * speedModif;
                //ObstacleRig.velocity = new Vector2(SpeedToRight * speedModif, ObstacleRig.velocity.y);
                if (transform.position == SecondPoint.position)
                {
                    CurrentPoint = MovingPoints.First;
                    yield return new WaitForSeconds(StopTime);
                }
            }
        }
    }
}
