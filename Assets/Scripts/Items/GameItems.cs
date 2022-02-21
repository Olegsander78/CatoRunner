using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItems : MonoBehaviour
{
    //public int ScoreValue = 1;

    public GameObject PickUpSoundPrefab;
    

    public  virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject newSound = Instantiate(PickUpSoundPrefab);
            newSound.GetComponent<AudioSource>().Play();
            Destroy(newSound, 1f);
            Destroy(gameObject);
        }
    }
}
