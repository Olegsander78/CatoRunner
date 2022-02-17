using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    [Header("Set in Inspector")]
    ////Pattern creating Apple
    //public GameObject applePrefab;
        
    public float speed = 1f;
    
    public float leftAndRightEdge = 2f;
    //public float chanceToChangeDirection = 0.1f;

    ////The frequency at which the apples are instantiated.
    //public float secondsBetweenAppleDrops = 1f;

    public Rigidbody2D ObstacleRig;

    private void Start()
    {
        ObstacleRig = GetComponent<Rigidbody2D>();
    }

    //void Start()
    //{
    //    ////Drop apples once a second.
    //    //Invoke("DropApple", 2f);
    //}
    //void DropApple()
    //{
    //    GameObject apple = Instantiate<GameObject>(applePrefab);
    //    apple.transform.position = transform.position;
    //    Invoke("DropApple", secondsBetweenAppleDrops);
    //}


    // Update is called once per frame
    void Update()
    {
        //Simple moving        
        ObstacleRig.velocity = transform.right * -speed;
        float posX = transform.position.x;
        Debug.Log(transform.right);
        ////Change of direction
        //if (posX < -leftAndRightEdge)
        //{
        //    speed = Mathf.Abs(speed);
        //}
        //else
        //{
        //    if (posX > leftAndRightEdge)
        //    {
        //        speed = -Mathf.Abs(speed);
        //    }
        //}
    }

    void FixedUpdate()
    {
        //if (Random.value < chanceToChangeDirection)
        //{
        //    speed *= -1;
        //}
    }
}
