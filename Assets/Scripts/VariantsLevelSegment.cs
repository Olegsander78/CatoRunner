using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariantsLevelSegment : MonoBehaviour
{
    [SerializeField] private List<ScoreItemsCreator> _variantsScoreItemsCreator;

    [SerializeField] private List<GameObject> _variantsSpawnsScoreItems;
    [SerializeField] private int _defaultVariantSpawnsScoreItems;

    //private void Start()
    //{
    //    for (int i = 0; i < _variantsSpawnsScoreItems.Count; i++)
    //    {
    //        _variantsSpawnsScoreItems[i].SetActive(false);
    //    }
    //    _variantsSpawnsScoreItems[_defaultVariantSpawnsScoreItems].SetActive(true);
    //    //_variantsScoreItemsCreator[_defaultVariantSpawnsScoreItems].GenerateScoreItems();
    //}

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


    //public void RollVariantSpawnScoreItems()
    //{
    //    int variantSpawn = Random.Range(0, _variantsScoreItemsCreator.Count);
    //    _variantsScoreItemsCreator[variantSpawn].GenerateScoreItems();
    //}
}
