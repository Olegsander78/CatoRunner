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
        _bgMusic.PlayMusic(BGMusic.MusicType.MainMenu);
        DontDestroyOnLoad(this);
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

    // AudioSource is assigned on object, enemy, player

    //public void PlaySound(SFX.SFXTypeItems sound, AudioSource audioSource)
    //{
    //    _sFX.PlaySFXItems(sound,audioSource);
    //}

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


