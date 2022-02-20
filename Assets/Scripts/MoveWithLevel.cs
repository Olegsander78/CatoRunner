using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithLevel : MonoBehaviour
{
    [SerializeField] private Rigidbody2D ObstacleRig;

    [SerializeField] private Level Level;

    private void Start()
    {
        Level = FindObjectOfType<Level>().gameObject.GetComponent<Level>();

        ObstacleRig = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        ObstacleRig.velocity = transform.right * -Level.SpeedLevel;
    }
}
