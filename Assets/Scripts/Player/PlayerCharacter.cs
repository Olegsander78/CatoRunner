using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour
{    
    [SerializeField] private PlayerHealth _playerHealth;
    public PlayerHealth PlayerHealth => _playerHealth;

    [SerializeField] private PlayerMove _playerMove;
    public PlayerMove PlayerMove => _playerMove;
    
    [SerializeField] private bool _isSpeedUped = false;

    //[SerializeField] private bool _isFinishedSpeedUP = true;

    public bool IsSpeedUped => _isSpeedUped;

    public SpriteRenderer ShieldSprite;
       
    
    public void ProtectionUp(float protectionTime)
    {
        PlayerHealth.StartInvulnerable(protectionTime);
        OnShield(protectionTime);
    } 
    
    public void OnShield(float duration)
    {
        GameController.Instance.SoundController.PlaySound(SFX.SFXTypeItems.PickUpShield);
        StartCoroutine(OnShieldRoutina(duration));
    }
    private IEnumerator OnShieldRoutina(float duration)
    {
        ShieldSprite.enabled = true;
        yield return new WaitForSeconds(duration);
        ShieldSprite.enabled = false;
    }

    public void StartSpeedUP(float speedUPModif, float speedUPTime)
    {
        GameController.Instance.SoundController.PlaySound(SFX.SFXTypeItems.PickUpSpeed);
        if (!IsSpeedUped)
        {
            StartCoroutine(SpeedUP(speedUPModif, speedUPTime));
        }
        else
        {
            speedUPModif = 1f;
            StartCoroutine(SpeedUP(speedUPModif, speedUPTime));
        }

        //TRIED TO DO CONTINUED SPEEDUP EFFECT

        //if (!IsSpeedUped && _isFinishedSpeedUP)
        //{
        //    StartCoroutine(SpeedUP(speedUPModif, speedUPTime));
        //}else if(IsSpeedUped && !_isFinishedSpeedUP)
        //{
        //    speedUPModif = 1f;
        //    StartCoroutine(SpeedUP(speedUPModif, speedUPTime));
        //}
    }

    private IEnumerator SpeedUP(float speedUPModif, float speedUPTime)
    {
        GameController.Instance.LevelController.CurrentLevel.ChangeSpeedLevel(speedUPModif);
        _isSpeedUped = true;
        //_isFinishedSpeedUP = false;
        //Debug.Log(speedUPTime);
        yield return new WaitForSeconds(speedUPTime);

        GameController.Instance.LevelController.CurrentLevel.SetStartSpeedLevels();
        _isSpeedUped = false;
        //_isFinishedSpeedUP = true;
    }
}
