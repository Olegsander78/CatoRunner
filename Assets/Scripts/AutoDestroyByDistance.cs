using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyByDistance : MonoBehaviour
{
    private const float LEFT_LENGTH_AUTODESTROY = -100f;
    private const float RIGHT_LENGTH_AUTODESTROY = 100f;
    private const float DOWN_LENGTH_AUTODESTROY = -30f;


    private void Update()
    {
        DestroyByDistance();
    }
    private void DestroyByDistance()
    {
        if (transform.position.x < LEFT_LENGTH_AUTODESTROY || transform.position.x > RIGHT_LENGTH_AUTODESTROY || transform.position.y < DOWN_LENGTH_AUTODESTROY)
        {
            Destroy(gameObject);
        }
    }
}