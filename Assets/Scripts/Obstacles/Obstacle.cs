using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{   
    //[SerializeField] private float _speedObstacle = 0.005f;

    public GameObject SawSound;
    public GameObject SawingPlayerSound;

    public Animator Animator;

    private void Update()
    {
        //transform.Translate(Vector2.left * _speedObstacle * Time.deltaTime);
    }
}
