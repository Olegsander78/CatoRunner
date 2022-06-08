using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleCreator : MonoBehaviour
{
    private const int MIN_OBSTACLES = 1;
    private const int MAX_OBSTACLES = 3;
    private const float DISTANCE_BETWEEN_OBSTACLES = 1.4f;

    public Transform Spawn;
    public Transform APosition;
    public Transform BPosition;

    public List<GameObject> PrefabObstacles;
    [SerializeField] private float _distanceBetweenMovingObstacles = 2f;

    private Vector3 _nextSpawnPositionItem;

    [ContextMenu("GenObstacles")]
    public void GenerateObstacles()
    {
        int indexPrefab = Random.Range(0, PrefabObstacles.Count);

        _nextSpawnPositionItem = Spawn.position;

        int amountObstacles = Random.Range(MIN_OBSTACLES, MAX_OBSTACLES);

        for (int i = 0; i < amountObstacles; i++)
        {
            GameObject prefObstacle = Instantiate(PrefabObstacles[indexPrefab], _nextSpawnPositionItem, Quaternion.identity);
            prefObstacle.transform.parent = Spawn;
            if (prefObstacle.GetComponent<Obstacle>().IsMovingObstacle)
            {
                if (prefObstacle.GetComponentInChildren<LocalMoveObstacle>())
                {
                    prefObstacle.GetComponentInChildren<LocalMoveObstacle>().FirstPoint = APosition;
                    prefObstacle.GetComponentInChildren<LocalMoveObstacle>().SecondPoint = BPosition;
                    _nextSpawnPositionItem += new Vector3(_distanceBetweenMovingObstacles, 0f, 0f);
                    var dis = _distanceBetweenMovingObstacles;
                    Debug.Log("Get LocalMove script " + dis);
                    continue;
                }
            }
            _nextSpawnPositionItem += new Vector3(DISTANCE_BETWEEN_OBSTACLES, 0f, 0f);
            var dis2 = DISTANCE_BETWEEN_OBSTACLES;
            Debug.Log("Don't Get LocalMove script " + dis2);
        }
    }
}
