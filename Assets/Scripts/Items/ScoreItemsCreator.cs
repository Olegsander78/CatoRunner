using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItemsCreator : MonoBehaviour
{
    private const int MIN__SCORE_ITEMS = 5;
    private const int MAX__SCORE_ITEMS = 10;

    public Transform Spawn;

    [SerializeField] private List<GameObject> _prefabScoreItems;
    

    [ContextMenu("GenScoreItems")]
    public void GenerateScoreItems()
    {
        int indexPrefab = Random.Range(0, _prefabScoreItems.Count);
        Vector3 nextSpawnPositionItem = Spawn.localPosition;
        for (int i = 0; i < Random.Range(MIN__SCORE_ITEMS, MAX__SCORE_ITEMS); i++)
        {            
            GameObject prefScoreItem = Instantiate(_prefabScoreItems[indexPrefab], nextSpawnPositionItem, Spawn.rotation);
            nextSpawnPositionItem.x += 1f;
        }
    }
}
