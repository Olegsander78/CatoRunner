using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItems : GameItems
{
    public int Health = 1;
    [SerializeField] private bool isFullHP;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().AddHealth(Health);
            if (isFullHP)
            {
                GameController.Instance.SoundController.PlaySound(SFX.SFXTypeItems.PickUpFullHP);
            }
            else
            {
                GameController.Instance.SoundController.PlaySound(SFX.SFXTypeItems.PickUpHealth);
            }
            Destroy(gameObject);
        }
    }
}
