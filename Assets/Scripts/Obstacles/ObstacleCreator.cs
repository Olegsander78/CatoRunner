using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleCreator : MonoBehaviour
{
    private const int MIN_SCORE_ITEMS = 1;
    private const int MAX_SCORE_ITEMS = 4;
    private const float DISTANCE_BETWEEN_ITEMS = 2f;

    public Transform Spawn;

    public List<GameObject> PrefabObstacles;

    public UnityEvent OnCreateObstacle;

    [ContextMenu("GenObstacles")]
    public void GenerateObstacles()
    {
        int indexPrefab = Random.Range(0, PrefabObstacles.Count);
        Vector3 nextSpawnPositionItem = Spawn.position;
        for (int i = 0; i < Random.Range(MIN_SCORE_ITEMS, MAX_SCORE_ITEMS); i++)
        {
            GameObject prefObstacle = Instantiate(PrefabObstacles[indexPrefab], nextSpawnPositionItem, Quaternion.identity);
            prefObstacle.transform.parent = Spawn;
            OnCreateObstacle.Invoke();
            nextSpawnPositionItem += new Vector3(DISTANCE_BETWEEN_ITEMS, 0f, 0f);
        }
    }
}
