using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class AdYAManager : MonoBehaviour
{
    private const int AMOUNT_HP_FOR_AD = 1;
    private const int AMOUNT_SCORE_FOR_AD = 500;

    [DllImport("__Internal")]
    private static extern void ShowFullscreenAdv();

    [DllImport("__Internal")]
    private static extern void TestLog();

    [DllImport("__Internal")]
    private static extern void ShowRewardedVideoForHP();

    [DllImport("__Internal")]
    private static extern void ShowRewardedVideoForScore();


    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void PlayAdForHP()
    {
        Debug.Log("Showing AdHP");
        StopTimeGameForAd();
        ShowRewardedVideoForHP();
    }

    public void PlayAdForScore()
    {
        Debug.Log("Showing AdScore");
        StopTimeGameForAd();
        ShowRewardedVideoForScore();
    }

    public void RewardAdForHP()
    {
        Debug.Log("YA Ads Rewarded HP Ad Completed");
        GameController.Instance.LevelController.CurrentLevel.PlayerCharacter.GetComponent<PlayerHealth>().AddHealth(AMOUNT_HP_FOR_AD);
        ReturnTimeGame();
    }

    public void RewardAdForScore()
    {
        Debug.Log("YA Ads Rewarded Score Ad Completed");
        ReturnTimeGame();
        GameController.Instance.PlayerSession.AddScore(AMOUNT_SCORE_FOR_AD);
        GameController.Instance.EventBus.OnCoinCollected(AMOUNT_SCORE_FOR_AD);
    }

    public void StopTimeGameForAd()
    {
        Time.timeScale = 0f;
    }

    public void ReturnTimeGame()
    {
        Time.timeScale = GameController.Instance.LevelController.CurrentLevel.SpeedLevel;
    }

    public void StartShowFullscreenAdv()
    {
        StopTimeGameForAd();
        ShowFullscreenAdv();
    }
}
