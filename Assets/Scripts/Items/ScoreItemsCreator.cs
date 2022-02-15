using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItemsCreator : MonoBehaviour
{
    private const int MIN_SCORE_ITEMS = 7;
    private const int MAX_SCORE_ITEMS = 12;
    private const float DISTANCE_BETWEEN_ITEMS = 1f;

    public Transform Spawn;

    [SerializeField] private List<GameObject> _prefabScoreItems;

    [ContextMenu("GenScoreItems")]
    public void GenerateScoreItems()
    {
        int indexPrefab = Random.Range(0, _prefabScoreItems.Count);
        Vector3 nextSpawnPositionItem = Spawn.position;
        for (int i = 0; i < Random.Range(MIN_SCORE_ITEMS, MAX_SCORE_ITEMS); i++)
        {
            GameObject prefScoreItem = Instantiate(_prefabScoreItems[indexPrefab], nextSpawnPositionItem, Quaternion.identity);
            prefScoreItem.transform.parent = Spawn;
            nextSpawnPositionItem += new Vector3(DISTANCE_BETWEEN_ITEMS, 0f, 0f);
        }
    }
}
