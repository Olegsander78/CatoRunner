using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private const float LEFT_LENGTH_AUTODESTROY = -60f;
    private const float RIGHT_LENGTH_AUTODESTROY = 80f;
    private const float DOWN_LENGTH_AUTODESTROY = -20f;

    [SerializeField] private float _speedObstacle = 0.005f;

    public GameObject SawSound;
    public GameObject SawingPlayerSound;

    public Animator Animator;


    private void Update()
    {
        transform.Translate(Vector2.left * _speedObstacle * Time.deltaTime);
        AutoDestroy();
    }


    public void AutoDestroy()
    {
        if (transform.position.x < LEFT_LENGTH_AUTODESTROY || transform.position.x > RIGHT_LENGTH_AUTODESTROY || transform.position.y < DOWN_LENGTH_AUTODESTROY)
        {
            Destroy(gameObject);
        }
    }

}
