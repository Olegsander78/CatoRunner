using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateItemsCreator : MonoBehaviour
{
    public Transform Spawn;

    [SerializeField] private List<GameObject> _prefabStateItems;

    [ContextMenu("GenStateItems")]
    public void GenerateStateItems()
    {
        int indexPrefab = Random.Range(0, _prefabStateItems.Count-1);

        Vector3 nextSpawnPositionItem = Spawn.position;

        GameObject prefScoreItem = Instantiate(_prefabStateItems[indexPrefab], nextSpawnPositionItem, Quaternion.identity);
        prefScoreItem.transform.parent = Spawn;
    }
}
