using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItems : MonoBehaviour
{   
    [SerializeField] private SFX.SFXTypeItems _pickUpSound;
    public SFX.SFXTypeItems PickUpSound => _pickUpSound;

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
