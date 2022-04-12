using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItems : GameItems
{
    public int ScoreValue = 1;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {            
            GameController.Instance.PlayerProfile.AddScore(ScoreValue);
            GameController.Instance.SoundController.PlaySound(PickUpSound);
            Destroy(gameObject);
        }
    }
}
