using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSegment : MonoBehaviour
{
    [SerializeField] private List<GameObject> _variantLevelSegment;
    [SerializeField] private int _defaultVariant;

    private void Start()
    {
        for (int i = 0; i < _variantLevelSegment.Count; i++)
        {
            _variantLevelSegment[i].SetActive(false);
        }
        _variantLevelSegment[_defaultVariant].SetActive(true);
    }

    public void RollVariant()
    {
        for (int i = 0; i < _variantLevelSegment.Count; i++)
        {
            _variantLevelSegment[i].SetActive(false);
        }
        _variantLevelSegment[Random.Range(0, _variantLevelSegment.Count)].SetActive(true);
    }




}
