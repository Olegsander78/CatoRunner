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
            GameController.Instance.PlayerSession.AddScore(ScoreValue);
            GameController.Instance.SoundController.PlaySound(PickUpSound);
            GameController.Instance.EventBus.OnCoinCollected(ScoreValue);
            Destroy(gameObject);
        }
    }
}
