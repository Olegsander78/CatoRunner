using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItems : MonoBehaviour
{
    public int ScoreValue = 1;

    [SerializeField] private float _speedLevel = 1.5f;

    public GameObject PickUpSound;
    

    private void Update()
    {
        //transform.Translate(Vector2.left * _speedLevel * Time.deltaTime);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerCharacter>().AddScore(ScoreValue);
            GameObject newSound = Instantiate(PickUpSound);
            newSound.GetComponent<AudioSource>().Play();
            Destroy(newSound, 1f);
            Destroy(gameObject);
        }
    }
}
