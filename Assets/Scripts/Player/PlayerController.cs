using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMove _playerMove;

    private void OnMouseDown()
    {
        _playerMove.TryJump();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");
            _playerMove.TryJump();
        }

        if (Input.touches.Length > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("Touch");
            _playerMove.TryJump();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse");
            _playerMove.TryJump();
        }
    }
}
