using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSegment : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    public Rigidbody2D Rigidbody => _rb;

    [SerializeField] private List<GameObject> _variants;
    [SerializeField] private int _defaultVariantLeveSegment;

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
        RollLevelObjects(numberVariantLS);
    }

    private void RollLevelObjects(int numberVariant) => StartCoroutine(RollObjects(numberVariant));

    private IEnumerator RollObjects(int numberVariant)
    {
        yield return new WaitForSeconds(0.2f);

        _variants[numberVariant].GetComponent<VariantsLevelSegment>().RollVariantSpawnsScoreItems();
        _variants[numberVariant].GetComponent<VariantsLevelSegment>().RollVariantSpawnsObstacles();
        _variants[numberVariant].GetComponent<VariantsLevelSegment>().RollVariantSpawnsEnemies();
        _variants[numberVariant].GetComponent<VariantsLevelSegment>().RollVariantSpawnsStateItems();
    }   
}
