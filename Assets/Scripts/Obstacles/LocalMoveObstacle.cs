using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LocalMoveObstacle : MonoBehaviour
{
    public enum PointsForMoving
    {
        ToFirst = 0,
        ToSecond = 1
    }
    public enum LocalDirectionMovement
    {
        Vertical = 0,
        Horizontal = 1,
        Diagonal = 3
    }

    [Header("Points Parameters")]
    [SerializeField] private Transform _firstPoint;
    [SerializeField] private Transform _secondPoint;

    [Header("Obstacle Parameters")]
    [SerializeField] private float _speedToFirstPoint;
    [SerializeField] private float _speedToSecondPoint;

    [SerializeField] private float _delayOnPoint;

    [SerializeField] private PointsForMoving CurrentPoint = PointsForMoving.ToFirst;
    [SerializeField] private LocalDirectionMovement DirectionMovementObstacle;

    public Rigidbody2D ObstacleRig;

    public Transform FirstPoint { get => _firstPoint; set => _firstPoint = value; }
    public Transform SecondPoint { get => _secondPoint; set => _secondPoint = value; }

    private void Start()
    {
        ObstacleRig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float speedUpLevelModif = GameController.Instance.LevelController.CurrentLevel.SpeedLevel
            / GameController.Instance.LevelController.CurrentLevel.StartSpeedLevel;
       
        if(DirectionMovementObstacle == LocalDirectionMovement.Horizontal)
        {
            StartMoveObstacleHorizontal(speedUpLevelModif);
        }else if(DirectionMovementObstacle == LocalDirectionMovement.Vertical)
        {
            StartMoveObstacleVertical(speedUpLevelModif);
        }else if(DirectionMovementObstacle == LocalDirectionMovement.Diagonal)
        {
            StartMoveObstacleDiagonal(speedUpLevelModif);
        }        
    }

    public void StartMoveObstacleHorizontal(float speedModif)
    {
        StartCoroutine(MoveObstaclesHorizontal(speedModif));
    }
    private IEnumerator MoveObstaclesHorizontal(float speedModif)
    {
        if (_firstPoint != null && _secondPoint != null)
        {
            if (CurrentPoint == PointsForMoving.ToFirst)
            {
                ObstacleRig.velocity = -transform.right * _speedToFirstPoint * speedModif;
                if (transform.position.x < _firstPoint.position.x)
                {
                    CurrentPoint = PointsForMoving.ToSecond;
                    yield return new WaitForSeconds(_delayOnPoint);
                }
            }
            else
            {
                ObstacleRig.velocity = transform.right * _speedToSecondPoint * speedModif;
                if (transform.position.x > _secondPoint.position.x)
                {
                    CurrentPoint = PointsForMoving.ToFirst;
                    yield return new WaitForSeconds(_delayOnPoint);
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
        if (_firstPoint != null && _secondPoint != null)
        {
            if (CurrentPoint == PointsForMoving.ToFirst)
            {
                ObstacleRig.transform.position += transform.up * _speedToFirstPoint * speedModif * Time.deltaTime;
                //ObstacleRig.velocity = new Vector2(SpeedToLeft * speedModif, ObstacleRig.velocity.y);
                if (transform.position.y > _secondPoint.position.y)
                {
                    CurrentPoint = PointsForMoving.ToSecond;
                    yield return new WaitForSeconds(_delayOnPoint);
                }
            }
            else
            {
                ObstacleRig.transform.position -= transform.up * _speedToSecondPoint * speedModif * Time.deltaTime;
                //ObstacleRig.velocity = new Vector2(SpeedToRight * speedModif, ObstacleRig.velocity.y);
                if (transform.position.y < _firstPoint.position.y)
                {
                    CurrentPoint = PointsForMoving.ToFirst;
                    yield return new WaitForSeconds(_delayOnPoint);
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
        if (_firstPoint != null && _secondPoint != null)
        {
            Debug.Log("Start MoveObsDiag");
            if (CurrentPoint == PointsForMoving.ToFirst)
            {
                Debug.Log("Start FirstPoint");
                Vector2 dir = _firstPoint.position - transform.position;
                ObstacleRig.velocity = dir.normalized * _speedToFirstPoint * speedModif;
                //Debug.Log(dir);
                if (ObstacleRig.transform.position.x < _firstPoint.position.x && ObstacleRig.transform.position.y < _firstPoint.position.y)
                {
                    Debug.Log("End FirstPoint");
                    CurrentPoint = PointsForMoving.ToSecond;
                    yield return new WaitForSeconds(_delayOnPoint);
                }
            }
            else
            {
                Debug.Log("Start SecondPoint");
                Vector2 dirReturn = _secondPoint.position - transform.position;
                ObstacleRig.velocity = dirReturn.normalized * _speedToSecondPoint * speedModif;
                //Debug.Log(dirReturn);
                if (ObstacleRig.transform.position.x > _secondPoint.position.x && ObstacleRig.transform.position.y > _secondPoint.position.y)
                {
                    Debug.Log("End SecondPoint");
                    CurrentPoint = PointsForMoving.ToFirst;
                    yield return new WaitForSeconds(_delayOnPoint);
                }
            }
        }
    }
}
