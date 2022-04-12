using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void StopBGMusic()
    {
        _bgMusic.StopMusic();
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
}


