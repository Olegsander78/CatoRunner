using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : Sounds
{
    public enum SFXType
    {
        PickUpCoin = 1,
        DamagePlayer = 2
    }

    [System.Serializable]
    public class SFXNote
    {
        public SFXType Sound;
        public AudioClip AudioClip;
    }

    [SerializeField] private List<SFXNote> _audioSourcesSFX;
    [SerializeField] private SFXType _currentAudioSourcesSFX;
    [SerializeField] private AudioSource _audioSource;


    public void PlayMusic(SFXType sound)
    {
        foreach (var sfxNote in _audioSourcesSFX)
        {
            if (sfxNote.Sound == sound)
            {
                _currentAudioSourcesSFX = sound;
                _audioSource.clip = sfxNote.AudioClip;
                _audioSource.Play();
                return;
            }
        }
    }
}
