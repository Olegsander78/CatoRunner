using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSegment : MonoBehaviour
{
    [SerializeField] private List<GameObject> _variants;
    [SerializeField] private int _defaultVariantLeveSegment;
    [SerializeField] private List<VariantsLevelSegment> _variantsScriptsVariants;

    private void Start()
    {
        for (int i = 0; i < _variants.Count; i++)
        {
            _variants[i].SetActive(false);
        }
        _variants[_defaultVariantLeveSegment].SetActive(true);
    }

    public void RollVariantLevelSegment()
    {
        for (int i = 0; i < _variants.Count; i++)
        {
            _variants[i].SetActive(false);
        }
        int numberVariantLS = Random.Range(0, _variants.Count);
        _variants[numberVariantLS].SetActive(true);
        _variantsScriptsVariants[numberVariantLS].RollVariantSpawnsScoreItems();
    }

   
}
