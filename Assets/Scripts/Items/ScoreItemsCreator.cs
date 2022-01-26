using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateScoreItems : MonoBehaviour
{
    private const int MIN__SCORE_ITEMS = 3;
    private const int MAX__SCORE_ITEMS = 8;

    //[SerializeField] private List<GameObject> _variantsSpawnScoreItems;
    [//SerializeField] private int _defaultSpawnScoreItems;
    [SerializeField] private List<GameObject> _prefabScoreItems;

    public Transform Spawn;
    public GameObject ScoreItemPrefab;

    //private ScoreItems[] _scoreItems;


    //public void RollVariantSpawnScoreItems()
    //{
      
    //    int variantSpawn = Random.Range(0, _variantsSpawnScoreItems.Count);
    //    _variantsSpawnScoreItems[variantSpawn].SetActive(true);
    //    GenerateScoreItems(_variantsSpawnScoreItems[variantSpawn]);
    //}

    public void GenerateScoreItems()
    {
        int indexPrefab = Random.Range(0, _prefabScoreItems.Count);
        for (int i = 0; i < Random.Range(MIN__SCORE_ITEMS, MAX__SCORE_ITEMS); i++)
        {
            Vector3 nextSpawnPositionItem = Spawn.localPosition;
            GameObject prefScoreItem = Instantiate(_prefabScoreItems[indexPrefab], nextSpawnPositionItem, Spawn.rotation);
            //nextSpawnPositionItem.x += 1f;
        }
    }
}
