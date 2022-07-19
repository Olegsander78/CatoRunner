using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class YandexSDK : MonoBehaviour
{
    private const int AMOUNT_HP_FOR_AD = 1;
    private const int AMOUNT_SCORE_FOR_AD = 500;

    [DllImport("__Internal")]
    private static extern void ShowPlayAdForHP();

    [DllImport("__Internal")]
    private static extern void ShowPlayAdForScore();
    
    [DllImport("__Internal")]
    private static extern void StartShowFullScreenAds();

    public static YandexSDK Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void StartShowFullScreenADV()
    {
        GameController.Instance.SoundController.MuteBGMusic();
        StartShowFullScreenAds();
        GameController.Instance.SoundController.MuteBGMusic();
    }

    public void PlayAdForHP()
    {
        //Debug.Log("Showing AdHP");
        //StopTimeGameForAd();
        ShowPlayAdForHP();
    }

    public void PlayAdForScore()
    {
        //Debug.Log("Showing AdScore");
        //StopTimeGameForAd();
        ShowPlayAdForScore();
    }

    public void RewardAdForHP()
    {
        Debug.Log("YA Ads Rewarded HP Ad Completed");
        GameController.Instance.LevelController.CurrentLevel.PlayerCharacter.GetComponent<PlayerHealth>().AddHealth(AMOUNT_HP_FOR_AD);
        GameController.Instance.SoundController.MuteBGMusic();
        //ReturnTimeGame();
    }

    public void RewardAdForScore()
    {
        Debug.Log("YA Ads Rewarded Score Ad Completed");
        //ReturnTimeGame();
        GameController.Instance.PlayerSession.AddScore(AMOUNT_SCORE_FOR_AD);
        GameController.Instance.EventBus.OnCoinCollected(AMOUNT_SCORE_FOR_AD);
        GameController.Instance.SoundController.MuteBGMusic();
    }

    //public void StopTimeGameForAd()
    //{
    //    Time.timeScale = 0.1f;
    //}

    //public void ReturnTimeGame()
    //{
    //    Time.timeScale = GameController.Instance.LevelController.CurrentLevel.SpeedLevel;
    //}

    //public void StartFullscreenAdv()
    //{        
    //    StartShowFullScreenADV();
    //}
}
