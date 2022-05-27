using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsScreen : Screen
{
    [SerializeField] private Slider _volumeMusicSld;    
    [SerializeField] private Slider _volumeSoundSld;    
    [SerializeField] private Button _backBtn;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _nameGroupMusicAudioMixer;
    [SerializeField] private string _nameGroupSFXAudioMixer;
    [SerializeField] private int _indexMainMenuScene = 1;


    private void Start()
    {
        _audioMixer.GetFloat(_nameGroupMusicAudioMixer, out var valueMusic);
        _volumeMusicSld.value = valueMusic;
        _audioMixer.GetFloat(_nameGroupSFXAudioMixer, out var valueSFX);
        _volumeSoundSld.value = valueSFX;

        _backBtn.onClick.AddListener(GoBackMainMenu);
        _volumeMusicSld.onValueChanged.AddListener(ChangeVolumeMusic);
        _volumeSoundSld.onValueChanged.AddListener(ChangeVolumeSound);
    }

    public void ChangeVolumeMusic(float volume)
    {
        _audioMixer.SetFloat(_nameGroupMusicAudioMixer, volume);
    }
    public void ChangeVolumeSound(float volume)
    {
        _audioMixer.SetFloat(_nameGroupSFXAudioMixer, volume);
        if (Mathf.Abs(volume % 10) == 0)
        {
            GameController.Instance.SoundController.PlaySound(SFX.SFXTypeEvents.DamagePlayer);
        }
    }

    public void GoBackMainMenu()
    {
        GameController.Instance.SoundController.PlaySound(SFX.SFXTypeUI.ClickButton);
        if (SceneManager.GetActiveScene().buildIndex == _indexMainMenuScene)
        {
            GameController.Instance.ScreenController.PushScreen<MainMenuScreen>();
        }
        else
        {
            if (!GameController.Instance.LevelController.CurrentLevel.Quest.IsQuestFinished())
            {
                GameController.Instance.ScreenController.PopScreen();
                GameController.Instance.ScreenController.PushScreen<PauseScreen>();
            }
            else
            {
                GameController.Instance.ScreenController.PopScreen();
                GameController.Instance.ScreenController.PushScreen<MainMenuScreen>();
            }
        }                
    }
}
