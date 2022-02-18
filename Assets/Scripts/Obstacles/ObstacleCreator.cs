using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleCreator : MonoBehaviour
{
    private const int MIN_OBSTACLES = 1;
    private const int MAX_OBSTACLES = 4;
    private const float DISTANCE_BETWEEN_OBSTACLES = 1.4f;

    public Transform Spawn;

    public List<GameObject> PrefabObstacles;

    //public UnityEvent OnCreateObstacle;

    [ContextMenu("GenObstacles")]
    public void GenerateObstacles()
    {
        int indexPrefab = Random.Range(0, PrefabObstacles.Count);

        Vector3 nextSpawnPositionItem = Spawn.position;

        int amountObstacles = Random.Range(MIN_OBSTACLES, MAX_OBSTACLES);

        for (int i = 0; i < amountObstacles; i++)
        {
            GameObject prefObstacle = Instantiate(PrefabObstacles[indexPrefab], nextSpawnPositionItem, Quaternion.identity);
            prefObstacle.transform.parent = Spawn;
            //OnCreateObstacle.Invoke();
            nextSpawnPositionItem += new Vector3(DISTANCE_BETWEEN_OBSTACLES, 0f, 0f);
        }
    }
}
