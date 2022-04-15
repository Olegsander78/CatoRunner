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
            if (PrefabObstacles[indexPrefab].GetComponent<LocalMoveObstacle>())
            {
                PrefabObstacles[indexPrefab].GetComponent<LocalMoveObstacle>().LeftPoint = APosition;
                PrefabObstacles[indexPrefab].GetComponent<LocalMoveObstacle>().RightPoint = BPosition;
            }
            nextSpawnPositionItem += new Vector3(DISTANCE_BETWEEN_OBSTACLES, 0f, 0f);
        }
    }
}
