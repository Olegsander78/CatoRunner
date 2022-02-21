using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItems : GameItems
{
    public int Health = 1;

    public Collider2D Collider2D;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        collision.GetComponent<PlayerHealth>().AddHealth(Health);
    }


}
