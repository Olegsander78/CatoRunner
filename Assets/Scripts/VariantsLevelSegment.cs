using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariantsLevelSegment : MonoBehaviour
{
    [SerializeField] private List<GameObject> _variantsSpawnsScoreItems;
    [SerializeField] private List<GameObject> _variantsSpawnsStateItems;
    [SerializeField] private List<GameObject> _variantsSpawnObstacles;
    [SerializeField] private List<GameObject> _variantsSpawnEnemies;

    private void Start()
    {
        //SwitchOffVariantsSpawns();
    }

    private void SwitchOffVariantsSpawns()
    {
        for (int i = 0; i < _variantsSpawnsScoreItems.Count; i++)
        {
            _variantsSpawnsScoreItems[i].SetActive(false);
        }

        for (int i = 0; i < _variantsSpawnObstacles.Count; i++)
        {
            _variantsSpawnObstacles[i].SetActive(false);
        }

        for (int i = 0; i < _variantsSpawnEnemies.Count; i++)
        {
            _variantsSpawnObstacles[i].SetActive(false);
        }

        for (int i = 0; i < _variantsSpawnsStateItems.Count; i++)
        {
            _variantsSpawnObstacles[i].SetActive(false);
        }
    }

    public void RollVariantSpawnsScoreItems()
    {        
        for (int i = 0; i < _variantsSpawnsScoreItems.Count; i++)
        {
            _variantsSpawnsScoreItems[i].SetActive(false);
        }
        int numberVariantSpawn = Random.Range(0, _variantsSpawnsScoreItems.Count);
        if (_variantsSpawnsScoreItems[numberVariantSpawn] != null)
        {
            _variantsSpawnsScoreItems[numberVariantSpawn].SetActive(true);
            if (_variantsSpawnsScoreItems[numberVariantSpawn].GetComponent<ScoreItemsCreator>())
            {
                _variantsSpawnsScoreItems[numberVariantSpawn].GetComponent<ScoreItemsCreator>().GenerateScoreItems();
            }
        }
    }

    public void RollVariantSpawnsStateItems()
    {
        for (int i = 0; i < _variantsSpawnsStateItems.Count; i++)
        {
            _variantsSpawnsStateItems[i].SetActive(false);
        }
        int numberVariantSpawn = Random.Range(0, _variantsSpawnsStateItems.Count);
        if (_variantsSpawnsStateItems[numberVariantSpawn] != null)
        {
            _variantsSpawnsStateItems[numberVariantSpawn].SetActive(true);
            if (_variantsSpawnsStateItems[numberVariantSpawn].GetComponent<StateItemsCreator>())
            {
                _variantsSpawnsStateItems[numberVariantSpawn].GetComponent<StateItemsCreator>().GenerateStateItems();
            }
        }
    }

    public void RollVariantSpawnsObstacles()
    {
        for (int i = 0; i < _variantsSpawnObstacles.Count; i++)
        {
            _variantsSpawnObstacles[i].SetActive(false);
        }
        int numberVariantSpawn = Random.Range(0, _variantsSpawnObstacles.Count);

        if (_variantsSpawnObstacles[numberVariantSpawn] != null)
        {
            _variantsSpawnObstacles[numberVariantSpawn].SetActive(true);

            if (_variantsSpawnObstacles[numberVariantSpawn].GetComponent<ObstacleCreator>())
            {
                _variantsSpawnObstacles[numberVariantSpawn].GetComponent<ObstacleCreator>().GenerateObstacles();
            }
        }
    }

    public void RollVariantSpawnsEnemies()
    {
        for (int i = 0; i < _variantsSpawnEnemies.Count; i++)
        {
            _variantsSpawnEnemies[i].SetActive(false);
        }
        int numberVariantSpawn = Random.Range(0, _variantsSpawnEnemies.Count);

        if (_variantsSpawnEnemies[numberVariantSpawn] != null)
        {
            _variantsSpawnEnemies[numberVariantSpawn].SetActive(true);

            if (_variantsSpawnEnemies[numberVariantSpawn].GetComponent<EnemiesCreator>())
            {
                _variantsSpawnEnemies[numberVariantSpawn].GetComponent<EnemiesCreator>().GenerateEnemy();
            }
        }
    }
}
