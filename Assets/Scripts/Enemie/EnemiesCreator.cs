using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesCreator : MonoBehaviour
{
    public Transform Spawn;

    public List<GameObject> PrefabEnemies;

    [ContextMenu("GenEnemy")]
    public void GenerateEnemy()
    {
        int indexPrefab = Random.Range(0, PrefabEnemies.Count);

        Vector3 nextSpawnPositionItem = Spawn.position;

        GameObject prefObstacle = Instantiate(PrefabEnemies[indexPrefab], nextSpawnPositionItem, Quaternion.identity);
        prefObstacle.transform.parent = Spawn;
    }
}
