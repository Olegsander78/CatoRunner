using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariantsLevelSegment : MonoBehaviour
{
    [SerializeField] private List<ScoreItemsCreator> _variantsScoreItemsCreator;

    public void RollVariantSpawnScoreItems()
    {
        int variantSpawn = Random.Range(0, _variantsScoreItemsCreator.Count);
        _variantsScoreItemsCreator[variantSpawn].GenerateScoreItems();
    }
}
