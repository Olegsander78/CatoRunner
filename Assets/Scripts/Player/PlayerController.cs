using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private PlayerMove _playerMove;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(eventData.position);
    }

    private void OnMouseDown()
    {
        _playerMove.TryJump(_playerMove.JumpForce);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");
            _playerMove.TryJump(_playerMove.JumpForce);
        }
#if UNITY_ANDROID
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Debug.Log("Touch");
            _playerMove.TryJump(_playerMove.JumpForceForTuch);
        }
#elif UNITY_EDITOR

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse");
            _playerMove.TryJump(_playerMove.JumpForce);
        }
#endif
    }
}
