using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMove _playerMove;

    private void OnMouseDown()
    {
        _playerMove.TryJump(_playerMove.JumpForce);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
        {
            Debug.Log("Space");
            _playerMove.TryJump(_playerMove.JumpForce);
        }
#if UNITY_ANDROID
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            int cameraWidth = Camera.main.scaledPixelWidth;
            int cameraHeght = Camera.main.scaledPixelHeight;            

            if (Input.touches[0].position.x > cameraWidth * 0.02f && Input.touches[0].position.x < cameraWidth * 0.98f && Input.touches[0].position.y > cameraHeght * 0.2f && Input.touches[0].position.y < cameraHeght * 0.85f)
            {
                Debug.Log("Touch " + Input.touches[0].position);
                _playerMove.TryJump(_playerMove.JumpForceForTuch);
            }
        }
#endif
//#elif UNITY_EDITOR

        if (Application.platform != RuntimePlatform.Android)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump"))
            {
                int cameraWidth = Camera.main.scaledPixelWidth;
                int cameraHeght = Camera.main.scaledPixelHeight;

                if (Input.mousePosition.x > cameraWidth * 0.02f && Input.mousePosition.x < cameraWidth * 0.98f && Input.mousePosition.y > cameraHeght * 0.2f && Input.mousePosition.y < cameraHeght * 0.85f)
                {
                    Debug.Log("Mouse " + Input.mousePosition);
                    _playerMove.TryJump(_playerMove.JumpForce);
                }
            }
        }
//#endif
    }
}
