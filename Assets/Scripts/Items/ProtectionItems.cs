using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectionItems : GameItems
{
    [SerializeField] private float _protectionTime;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerCharacter>().ProtectionUp(_protectionTime);
            Destroy(gameObject);
        }
    }

}
