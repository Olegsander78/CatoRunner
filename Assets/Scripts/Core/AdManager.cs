using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    private const int AMOUNT_HP_FOR_AD = 1;
    private const int AMOUNT_SCORE_FOR_AD = 500;

#if UNITY_IOS
    private string gameId = "4818956";
#elif UNITY_ANDROID
    private string gameId = "4818957";
#elif UNITY_EDITOR
    private string gameId = "4818957";
#endif

    private string placementIdForHP = "clickReward";
    private string placementIdForScores = "Rewarded_Android";

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, true);
    }

    public void PlayAdForHP()
    {        
        Time.timeScale = 0f;
        Advertisement.Show(placementIdForHP);
    }

    public void PlayAdForScore()
    {
        Time.timeScale = 0f;
        Advertisement.Show(placementIdForScores);
    }
    public void OnUnityAdsDidError(string message)
    {
        Time.timeScale = 1f;
    }
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == "clickReward")
        {
            if (showResult == ShowResult.Finished)
            {
                GameController.Instance.LevelController.CurrentLevel.PlayerCharacter.GetComponent<PlayerHealth>().AddHealth(AMOUNT_HP_FOR_AD);
            }
        }else if (placementId == "Rewarded_Android")
        {
            if (showResult == ShowResult.Finished)
            {
                GameController.Instance.PlayerSession.AddScore(AMOUNT_SCORE_FOR_AD);
                GameController.Instance.EventBus.OnCoinCollected(AMOUNT_SCORE_FOR_AD);
            }
        }

            Time.timeScale = 1f;       
    }

    public void OnUnityAdsDidStart(string placementId)
    {

    }
    public void OnUnityAdsReady(string placementId)
    {
        Advertisement.Banner.SetPosition(BannerPosition.TOP_LEFT);
        Advertisement.Banner.Show("Banner_Android");
    }
}

