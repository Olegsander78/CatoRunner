using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsScreen : Screen
{
    //[SerializeField] private Toggle _soundTgl;
    [SerializeField] private Slider _volumeMusicSld;    
    [SerializeField] private Slider _volumeSoundSld;    
    [SerializeField] private Button _backBtn;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _nameGroupAudioMixer;


    private void Start()
    {
        _backBtn.onClick.AddListener(GoBackMainMenu);
    }

    public void ChangeVolumeMusic(float volume)
    {
        _audioMixer.SetFloat(_nameGroupAudioMixer, volume);
    }
    public void ChangeVolumeSound(float volume)
    {
        _audioMixer.SetFloat(_nameGroupAudioMixer, volume);
    }

    public void GoBackMainMenu()
    {
        GameController.Instance.ScreenController.PushScreen<MainMenuScreen>();
    }

}
