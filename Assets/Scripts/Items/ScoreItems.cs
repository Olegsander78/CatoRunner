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
            //collision.GetComponent<PlayerCharacter>().AddScore(ScoreValue);
            GameController.Instance.PlayerProfile.AddScore(ScoreValue);
            GameObject newSound = Instantiate(PickUpSoundPrefab);
            newSound.GetComponent<AudioSource>().Play();
            Destroy(newSound, 1f);
            Destroy(gameObject);
        }
        
    }
}
