using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItems : GameItems
{
    public int Health = 1;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().AddHealth(Health);
            Destroy(gameObject);
        }        
    }
}
