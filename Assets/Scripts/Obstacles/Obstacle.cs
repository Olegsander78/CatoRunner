using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private bool _isMovingObstacle;
    public bool IsMovingObstacle => _isMovingObstacle;
}
