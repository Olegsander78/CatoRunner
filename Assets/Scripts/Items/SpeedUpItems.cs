using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItems : GameItems
{
    [SerializeField] private float _speedUPModif;
    [SerializeField] private float _speedUPTime;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {            
            collision.gameObject.GetComponent<PlayerCharacter>().StartSpeedUP(_speedUPModif, _speedUPTime);
            Destroy(gameObject);
        }
    }
}
