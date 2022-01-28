using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour
{    
    public float JumpForce;
    public Rigidbody2D Rig;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            Rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
        //Debug.Log(IsGrounded());
    }
    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0f, -1f, 0f),
            Vector2.down, 0.2f);
        return hit.collider != CompareTag("Ground");
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }  

}
