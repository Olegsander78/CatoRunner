using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariantsLevelSegment : MonoBehaviour
{
    [SerializeField] private List<GameObject> _variantsSpawnsScoreItems;
    [SerializeField] private List<GameObject> _variantsSpawnObstacles;
    [SerializeField] private int _defaultVariantSpawn = 0;

    private void Start()
    {
        for (int i = 0; i < _variantsSpawnsScoreItems.Count; i++)
        {
            _variantsSpawnsScoreItems[i].SetActive(false);            
        }

        for (int i = 0; i < _variantsSpawnObstacles.Count; i++)
        {
            _variantsSpawnObstacles[i].SetActive(false);
        }
        
        _variantsSpawnsScoreItems[_defaultVariantSpawn].SetActive(true);
        _variantsSpawnObstacles[_defaultVariantSpawn].SetActive(true);
        _variantsSpawnsScoreItems[_defaultVariantSpawn].GetComponent<ScoreItemsCreator>().GenerateScoreItems();
        _variantsSpawnObstacles[_defaultVariantSpawn].GetComponent<ObstacleCreator>().GenerateObstacles();
    }
    public void RollVariantSpawnsScoreItems()
    {        
        for (int i = 0; i < _variantsSpawnsScoreItems.Count; i++)
        {
            _variantsSpawnsScoreItems[i].SetActive(false);
        }
        int numberVariantSpawn = Random.Range(0, _variantsSpawnsScoreItems.Count);
        _variantsSpawnsScoreItems[numberVariantSpawn].SetActive(true);
        _variantsSpawnsScoreItems[numberVariantSpawn].GetComponent<ScoreItemsCreator>().GenerateScoreItems();
    }

    public void RollVariantSpawnsObstacles()
    {
        for (int i = 0; i < _variantsSpawnObstacles.Count; i++)
        {
            _variantsSpawnObstacles[i].SetActive(false);
        }
        int numberVariantSpawn = Random.Range(0, _variantsSpawnObstacles.Count);
        _variantsSpawnObstacles[numberVariantSpawn].SetActive(true);        
        _variantsSpawnObstacles[numberVariantSpawn].GetComponent<ObstacleCreator>().GenerateObstacles();
    }
}
