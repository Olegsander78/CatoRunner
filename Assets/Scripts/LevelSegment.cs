using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSegment : MonoBehaviour
{
    [SerializeField] private List<GameObject> _variantsLevelSegment;
    [SerializeField] private int _defaultVariantLeveSegment;
    [SerializeField] private List<CreateScoreItems> _createScoreItemsList;

    private void Start()
    {
        for (int i = 0; i < _variantsLevelSegment.Count; i++)
        {
            _variantsLevelSegment[i].SetActive(false);
        }
        _variantsLevelSegment[_defaultVariantLeveSegment].SetActive(true);
        _variantsLevelSegment[_defaultVariantLeveSegment].GetComponentInChildren<CreateScoreItems>().RollVariantSpawnScoreItems();
        //_createScoreItemsList[0].RollVariantSpawnScoreItems();
    }

    public void RollVariantLevelSegment()
    {
        for (int i = 0; i < _variantsLevelSegment.Count; i++)
        {
            _variantsLevelSegment[i].SetActive(false);
        }
        int numberVariantLS = Random.Range(0, _variantsLevelSegment.Count);
        _variantsLevelSegment[numberVariantLS].SetActive(true);
        _variantsLevelSegment[numberVariantLS].GetComponentInChildren<CreateScoreItems>().RollVariantSpawnScoreItems();
        //_createScoreItems.RollVariantSpawnScoreItems();
    }
}
