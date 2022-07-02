using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener, IUnityAdsInitializationListener
{
    private const int AMOUNT_HP_FOR_AD = 1;
    private const int AMOUNT_SCORE_FOR_AD = 500;

    [SerializeField] private string _androidGameId;
    [SerializeField] private string _iOSGameId;
    [SerializeField] private bool _testMode = true;

#if UNITY_IOS
    private string _gameId = "4818956";
#elif UNITY_ANDROID
    private string _gameId = "4818957";
#elif UNITY_EDITOR
    private string _gameId = "4818957";
#endif

    private string _placementIdForHP = "clickReward";
    private string _placementIdForScores = "Rewarded_Android";
    private string _placementIdBanner = "Banner_Android";

    private void Awake()
    {
        InitializeAds();
        DontDestroyOnLoad(this);
    }
    //void Start()
    //{
    //    Advertisement.AddListener(this);
    //    Advertisement.Initialize(gameId, false, this);
    //}

    
    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
           ? _iOSGameId
           : _androidGameId;
        Advertisement.Initialize(_gameId, _testMode, this);
    }

    public void LoadAd()
    {
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Load(_placementIdBanner);
        Debug.Log("Loading Ad: " + _placementIdBanner);        
        Advertisement.Banner.Show(_placementIdBanner);

        Advertisement.Load(_placementIdForHP,this);
        Debug.Log("Loading Ad: " + _placementIdForHP);
        Advertisement.Load(_placementIdForScores,this);
        Debug.Log("Loading Ad: " + _placementIdForScores);
    }
         

    public void PlayAdForHP()
    {
        Debug.Log("Showing AdHP");
        Time.timeScale = 0f;
        Advertisement.Show(_placementIdForHP, this);
    }

    public void PlayAdForScore()
    {
        Debug.Log("Showing AdScore");
        Time.timeScale = 0f;
        Advertisement.Show(_placementIdForScores, this);
    }

    //public void OnUnityAdsDidError(string message)
    //{
    //    Time.timeScale = 1f;
    //}
    //public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    //{
    //    if (placementId == "clickReward")
    //    {
    //        if (showResult == ShowResult.Finished)
    //        {
    //            GameController.Instance.LevelController.CurrentLevel.PlayerCharacter.GetComponent<PlayerHealth>().AddHealth(AMOUNT_HP_FOR_AD);
    //        }
    //    }else if (placementId == "Rewarded_Android")
    //    {
    //        if (showResult == ShowResult.Finished)
    //        {
    //            GameController.Instance.PlayerSession.AddScore(AMOUNT_SCORE_FOR_AD);
    //            GameController.Instance.EventBus.OnCoinCollected(AMOUNT_SCORE_FOR_AD);
    //        }
    //    }

    //        Time.timeScale = 1f;       
    //}

    //public void OnUnityAdsDidStart(string placementId)
    //{

    //}
    //public void OnUnityAdsReady(string placementId)
    //{
    //    Advertisement.Banner.SetPosition(BannerPosition.TOP_LEFT);
    //    Advertisement.Banner.Show("Banner_Android");
    //}

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Ad Loaded: " + placementId);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {placementId}: {error.ToString()} - {message}");
        Time.timeScale = 1f;
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {placementId}: {error.ToString()} - {message}");
        Time.timeScale = 1f;
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId.Equals(_placementIdForHP))
        {
            Debug.Log("Unity Ads Rewarded HP Ad Completed");
            GameController.Instance.LevelController.CurrentLevel.PlayerCharacter.GetComponent<PlayerHealth>().AddHealth(AMOUNT_HP_FOR_AD);

            Advertisement.Load(_placementIdForHP, this);
        }

        if (placementId.Equals(_placementIdForScores))
        {
            Debug.Log("Unity Ads Rewarded Score Ad Completed");
            GameController.Instance.PlayerSession.AddScore(AMOUNT_SCORE_FOR_AD);
            GameController.Instance.EventBus.OnCoinCollected(AMOUNT_SCORE_FOR_AD);

            Advertisement.Load(_placementIdForScores, this);
        }

        //if (placementId.Equals(_placementIdForHP))
        //{
        //    if (showCompletionState.Equals(UnityAdsCompletionState.COMPLETED))
        //    {
        //        Debug.Log("Unity Ads Rewarded HP Ad Completed");
        //        GameController.Instance.LevelController.CurrentLevel.PlayerCharacter.GetComponent<PlayerHealth>().AddHealth(AMOUNT_HP_FOR_AD);

        //        Advertisement.Load(_placementIdForHP, this);
        //    }
        //}

        //if (placementId.Equals(_placementIdForScores))
        //{
        //    if (showCompletionState.Equals(UnityAdsCompletionState.COMPLETED))
        //    {
        //        Debug.Log("Unity Ads Rewarded Score Ad Completed");
        //        GameController.Instance.PlayerSession.AddScore(AMOUNT_SCORE_FOR_AD);
        //        GameController.Instance.EventBus.OnCoinCollected(AMOUNT_SCORE_FOR_AD);

        //        Advertisement.Load(_placementIdForScores, this);
        //    }
        //}

        Time.timeScale = 1f;
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        LoadAd();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }


    public void OnUnityAdsShowStart(string placementId)
    {

    }

    public void OnUnityAdsShowClick(string placementId)
    {

    }
}
