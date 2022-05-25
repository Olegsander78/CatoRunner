using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyByDistance : MonoBehaviour
{
    public Level Level;

    private void Awake()
    {
        //Level = FindObjectOfType<Level>().gameObject.GetComponent<Level>();
        Level = GameController.Instance.LevelController.CurrentLevel;
    }

    private void Update()
    {
        DestroyByDistance();
    }
    private void DestroyByDistance()
    {
        if (transform.position.x < (Level.MinCoordLevelSegX + Level.LENGHT_SEGMENT / 2))
        {
            Destroy(gameObject);
        }
    }
}
