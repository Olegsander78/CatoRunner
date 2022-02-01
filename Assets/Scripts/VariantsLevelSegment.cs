using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariantsLevelSegment : MonoBehaviour
{
    [SerializeField] private List<ScoreItemsCreator> _variantsScoreItemsCreator;

    [SerializeField] private List<GameObject> _variantsSpawnsScoreItems;
    [SerializeField] private int _defaultVariantSpawnsScoreItems;

    public void RollVariantSpawnsScoreItems()
    {
        for (int i = 0; i < _variantsSpawnsScoreItems.Count; i++)
        {
            _variantsSpawnsScoreItems[i].SetActive(false);
        }
        int numberVariantSpawn = Random.Range(0, _variantsSpawnsScoreItems.Count);
        _variantsSpawnsScoreItems[numberVariantSpawn].SetActive(true);
        _variantsScoreItemsCreator[numberVariantSpawn].GenerateScoreItems();
    }
}
