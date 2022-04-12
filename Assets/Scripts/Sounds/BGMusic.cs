using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : Sounds
{
    public enum MusicType
    {
        MainMenu = 1,
        LevelOneMusic = 2,
        LevelTwoMusic = 3,
        LevelThreeMusic = 4,
        LevelFourMusic = 5,
        LevelFiveMusic = 6
    }

    [System.Serializable]
    public class MusicNote
    {
        public MusicType Music;
        public AudioClip AudioClip;
    }

    [SerializeField] private List<MusicNote> _audioSourcesBGMusic;
    [SerializeField] private MusicType _currentAudioSourcesBGMusic;
    [SerializeField] private AudioSource _audioSource;

    public void PlayMusic(MusicType music)
    {
        foreach (var musicNote in _audioSourcesBGMusic)
        {
            if (musicNote.Music == music)
            {
                _currentAudioSourcesBGMusic = music;
                _audioSource.clip = musicNote.AudioClip;
                _audioSource.Play();
                return;
            }
        }
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
