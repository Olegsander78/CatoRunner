using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateScoreItems : MonoBehaviour
{
    private const int MIN__SCORE_ITEMS = 3;
    private const int MAX__SCORE_ITEMS = 8;

    [SerializeField] private List<GameObject> _variantsSpawnScoreItems;
    [SerializeField] private int _defaultSpawnScoreItems;
    [SerializeField] private List<GameObject> _prefabScoreItems;

    private void Start()
    {
        for (int i = 0; i < _variantsSpawnScoreItems.Count; i++)
        {
            _variantsSpawnScoreItems[i].SetActive(false);
        }
        _variantsSpawnScoreItems[_defaultSpawnScoreItems].SetActive(true);
    }

    public void RollVariantSpawnScoreItems()
    {
        for (int i = 0; i < _variantsSpawnScoreItems.Count; i++)
        {
            _variantsSpawnScoreItems[i].SetActive(false);
        }

        int variantSpawn = Random.Range(0, _variantsSpawnScoreItems.Count);
        _variantsSpawnScoreItems[variantSpawn].SetActive(true);
        GenerateScoreItems(_variantsSpawnScoreItems[variantSpawn]);
    }

    public void GenerateScoreItems(GameObject spawn)
    {
        for (int i = 0; i < Random.Range(MIN__SCORE_ITEMS,MAX__SCORE_ITEMS); i++)
        {
            Vector3 nextSpawnPositionItem = spawn.transform.position;
            GameObject prefScoreItem = Instantiate(_prefabScoreItems[Random.Range(0, _prefabScoreItems.Count)], nextSpawnPositionItem, transform.rotation);
            nextSpawnPositionItem.x += 1f;
        } 
    }
}
