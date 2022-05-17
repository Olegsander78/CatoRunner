using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithLevel : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Rig;

    [SerializeField] private Level Level;

    private void Start()
    {        
        Level = GameController.Instance.LevelController.CurrentLevel;

        Rig = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Rig.velocity = transform.right * -Level.SpeedLevel;
    }
}
