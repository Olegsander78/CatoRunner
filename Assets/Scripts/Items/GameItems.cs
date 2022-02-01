using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItems : MonoBehaviour
{
    private const float LEFT_LENGTH_AUTODESTROY = -60f;

    public int ScoreValue = 1;

    [SerializeField] private float _speedLevel = 1.5f;

    public GameObject PickUpSound;

    public HUDManager HUDManager;

    private void Start()
    {
        HUDManager = FindObjectOfType<HUDManager>();
    }


    private void Update()
    {
        transform.Translate(Vector2.left * _speedLevel * Time.deltaTime);
        AutoDestroy();
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HUDManager.AddScore(ScoreValue);
            GameObject newSound = Instantiate(PickUpSound);
            newSound.GetComponent<AudioSource>().Play();
            Destroy(newSound, 1f);
            Destroy(gameObject);
        }
    }

    public void AutoDestroy()
    {
        if (transform.position.x < LEFT_LENGTH_AUTODESTROY)
        {
            Destroy(gameObject);
        }
    }
}
