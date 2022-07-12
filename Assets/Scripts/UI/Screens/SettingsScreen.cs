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

        if (PlayerPrefs.HasKey("VolumeMusic"))
        {
            _volumeMusicSld.value = LoadMusicVolume();
        }

        if (PlayerPrefs.HasKey("VolumeSound"))
        {
            _volumeSoundSld.value = LoadSoundVolume();
        }

        _volumeMusicSld.onValueChanged.AddListener(ChangeVolumeMusic);
        _volumeSoundSld.onValueChanged.AddListener(ChangeVolumeSound);

        _backBtn.onClick.AddListener(GoBackMainMenu);
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
        SaveMusicVolume(_volumeMusicSld.value);
        SaveSoundVolume(_volumeSoundSld.value);

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
    public void SaveMusicVolume(float volumeMusic)
    {
        PlayerPrefs.SetFloat("VolumeMusic", volumeMusic);
        PlayerPrefs.Save();
        Debug.Log("Save Music and Sound is done!");
    }

    public void SaveSoundVolume(float volumeSound)
    {
        PlayerPrefs.SetFloat("VolumeSound", volumeSound);
        PlayerPrefs.Save();
        Debug.Log("Save Sound and Sound is done!");
    }

    public float LoadMusicVolume()
    {
        if (PlayerPrefs.HasKey("VolumeMusic"))
        {
            Debug.Log("Music volume loaded from PlayerPref! " + PlayerPrefs.GetFloat("VolumeMusic"));
            return PlayerPrefs.GetFloat("VolumeMusic");
        }
        else
        {
            Debug.LogError("PlayerPref hasn't save data!");
            return 0;
        }
    }

    public float LoadSoundVolume()
    {
        if (PlayerPrefs.HasKey("VolumeSound"))
        {
            Debug.Log("Sound volume loaded from PlayerPref! " + PlayerPrefs.GetFloat("VolumeSound"));
            return PlayerPrefs.GetFloat("VolumeSound");
        }
        else
        {
            Debug.LogError("PlayerPref hasn't save data!");
            return 0;
        }
    }

    private void OnEnable()
    {
        if (GameObject.Find("_Player"))
            GameObject.Find("_Player").GetComponentInChildren<PlayerController>().enabled = false;
    }
}
