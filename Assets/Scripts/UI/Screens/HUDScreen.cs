using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDScreen : Screen
{    
    [SerializeField] private Button _pauseBtn;
    [SerializeField] private Button _musicBtn;
    [SerializeField] private Button _soundBtn;

    [SerializeField] private Button _adsHPBtn;
    [SerializeField] private Button _adsScoreBtn;

    [SerializeField] private Sprite _musicOnImg;
    [SerializeField] private Sprite _musicOffImg;
    [SerializeField] private Sprite _soundsOnImg;
    [SerializeField] private Sprite _soundsOffImg;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI PlayerHealthText;

    private void Start()
    {
        _pauseBtn.onClick.AddListener(ClickPause);
        _musicBtn.onClick.AddListener(OnMusicMute);
        _soundBtn.onClick.AddListener(OnSoundMute);

        _adsHPBtn.onClick.AddListener(OnClickAdHPBtn);
        _adsScoreBtn.onClick.AddListener(OnClickAdScoreBtn);
    }

    public void ClickPause()
    {
        GameController.Instance.SoundController.PlaySound(SFX.SFXTypeUI.ClickToggle);
        GameController.Instance.ScreenController.PushScreen<PauseScreen>();
        Time.timeScale = 0f;
    }  
    
    public void OnMusicMute()
    {
        GameController.Instance.SoundController.PlaySound(SFX.SFXTypeUI.ClickToggle);
        GameController.Instance.SoundController.MuteBGMusic();

        if (_musicBtn.image.sprite == _musicOnImg)
        {
            _musicBtn.image.sprite = _musicOffImg;
        }
        else
        {
            _musicBtn.image.sprite = _musicOnImg;
        }
    }

    public void OnSoundMute()
    {
        GameController.Instance.SoundController.PlaySound(SFX.SFXTypeUI.ClickToggle);
        GameController.Instance.SoundController.MuteSFX();

        if (_soundBtn.image.sprite == _soundsOnImg)
        {
            _soundBtn.image.sprite = _soundsOffImg;
        }
        else
        {
            _soundBtn.image.sprite = _soundsOnImg;
        }
    }

    public void OnClickAdHPBtn()
    {        
        //GameController.Instance.AdManager.PlayAdForHP();
        GameController.Instance.AdYAManager.PlayAdForHP();
    }

    public void OnClickAdScoreBtn()
    {
        //GameController.Instance.AdManager.PlayAdForScore();
        GameController.Instance.AdYAManager.PlayAdForScore();
    }

    public void UpdateScoreText(int currentScore)
    {
        ScoreText.text = " " + currentScore.ToString();
    }

    public void UpdateHealthView(int playerHealth)
    {
        PlayerHealthText.text = " " + playerHealth.ToString();
    }

    private void OnDestroy()
    {
        _pauseBtn.onClick.RemoveAllListeners();
        _musicBtn.onClick.RemoveAllListeners();
        _soundBtn.onClick.RemoveAllListeners();

        _adsHPBtn.onClick.RemoveAllListeners();
        _adsScoreBtn.onClick.RemoveAllListeners();
    }
}
