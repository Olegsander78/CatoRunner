using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    [SerializeField] private BGMusic _bgMusic;
    [SerializeField] private SFX _sFX;

    private void Awake()
    {
        InitSoundController();

        DestroyExtraSoundController();
    }

    private void InitSoundController()
    {
        _bgMusic.PlayMusic(BGMusic.MusicType.MainMenu);

        DontDestroyOnLoad(this);
    }

    private void DestroyExtraSoundController()
    {
        SoundController[] allSoundControllers = FindObjectsOfType<SoundController>();
        if (allSoundControllers.Length > 1)
        {
            Destroy(allSoundControllers[1].gameObject);
            GameController.Instance.SoundController.StopBGMusic();
            GameController.Instance.SoundController.PlayBGMusic(BGMusic.MusicType.MainMenu);
        }
    }

    public void PlayBGMusic(Level level)
    {
        BGMusic.MusicType musicType = level.BGMusicType;
        _bgMusic.PlayMusic(musicType);
    }
    public void PlayBGMusic(BGMusic.MusicType bGMusicType)
    {        
        _bgMusic.PlayMusic(bGMusicType);
    }


    public void StopBGMusic()
    {
        _bgMusic.StopMusic();
    }

    public void MuteBGMusic()
    {
        _bgMusic.MuteMusic();
    }    

    public void PlaySound(SFX.SFXTypeItems sound)
    {
        _sFX.PlaySFX(sound);
    }

    public void PlaySound(SFX.SFXTypeCreatures sound)
    {
        _sFX.PlaySFX(sound);
    }

    public void PlaySound(SFX.SFXTypeUI sound)
    {
        _sFX.PlaySFX(sound);
    }

    public void PlaySound(SFX.SFXTypeEvents sound)
    {
        _sFX.PlaySFX(sound);
    }

    public void StopSound()
    {
        _sFX.StopSFX();
    }

    public void MuteSFX()
    {
        _sFX.MuteSFX();
    }
}


