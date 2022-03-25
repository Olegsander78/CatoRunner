using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyByDistance : MonoBehaviour
{
    //private const float LEFT_LENGTH_AUTODESTROY = -200f;
    //private const float RIGHT_LENGTH_AUTODESTROY = 200f;
    //private const float DOWN_LENGTH_AUTODESTROY = -30f;

    public Level Level;

    private void Awake()
    {
        Level = FindObjectOfType<Level>().gameObject.GetComponent<Level>();
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
