using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItems : GameItems
{
    public int Health = 1;

    //public Collider2D Collider2D;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().AddHealth(Health);
            GameObject newSound = Instantiate(PickUpSoundPrefab);
            newSound.GetComponent<AudioSource>().Play();
            Destroy(newSound, 1f);
            Destroy(gameObject);
        }
        
    }


}
