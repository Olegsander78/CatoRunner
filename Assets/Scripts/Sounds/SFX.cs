using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : Sounds
{
    public enum SFXTypeItems
    {
        PickUpCoin = 1,
        PickUpHealth = 2,
        PickUpFullHP = 3,
        PickUpShield = 4,
        PickUpSpeed = 5,
        PickUpGem = 6
    }

    public enum SFXTypeCreatures
    {        
        DamageStampEnemy = 1,
        DamageUnstampEnemy = 2,
        DieStampEnemy = 3,
        DieUnstampEnemy = 4
    }

    public enum SFXTypeUI
    {
        ClickButton = 1,
        ClickToggle = 2
    }

    public enum SFXTypeEvents
    {
        GameOver = 1,
        WinLevel = 2,
        DamagePlayer = 3
    }

    [System.Serializable]
    public class SFXItemsNote
    {
        public SFXTypeItems SoundItem;
        public AudioClip AudioClip;
    }
    [System.Serializable]
    public class SFXCreaturesNote
    {
        public SFXTypeCreatures SoundCreatures;
        public AudioClip AudioClip;
    }
    [System.Serializable]
    public class SFXUINote
    {
        public SFXTypeUI SoundUI;
        public AudioClip AudioClip;
    }
    [System.Serializable]
    public class SFXEventsNote
    {
        public SFXTypeEvents SoundEvent;
        public AudioClip AudioClip;
    }

    [SerializeField] private List<SFXItemsNote> _audioItemsSFX;
    [SerializeField] private List<SFXCreaturesNote> _audioCreaturesSFX;
    [SerializeField] private List<SFXUINote> _audioUISFX;
    [SerializeField] private List<SFXEventsNote> _audioEventsSFX;
    [SerializeField] private AudioSource _audioSourceItems;
    [SerializeField] private AudioSource _audioSourceCreatures;
    [SerializeField] private AudioSource _audioSourceUI;
    [SerializeField] private AudioSource _audioSourceEvents;


    public void PlaySFX(SFXTypeItems sound)
    {
        foreach (var sfxNote in _audioItemsSFX)
        {
            if (sfxNote.SoundItem == sound)
            {
                _audioSourceItems.clip = sfxNote.AudioClip;
                _audioSourceItems.Play();
                return;
            }
        }
    }

    // AudioSource is assigned on object, enemy, player

    //public void PlaySFX(SFXTypeItems sound, AudioSource audioSource)
    //{
    //    foreach (var sfxNote in _audioItemsSFX)
    //    {
    //        if (sfxNote.SoundItem == sound)
    //        {
    //            audioSource.clip = sfxNote.AudioClip;
    //            audioSource.Play();
    //            return;
    //        }
    //    }
    //}
    public void PlaySFX(SFXTypeCreatures sound)
    {
        foreach (var sfxNote in _audioCreaturesSFX)
        {
            if (sfxNote.SoundCreatures == sound)
            {
                _audioSourceCreatures.clip = sfxNote.AudioClip;
                _audioSourceCreatures.Play();
                return;
            }
        }
    }

    public void PlaySFX(SFXTypeUI sound)
    {
        foreach (var sfxNote in _audioUISFX)
        {
            if (sfxNote.SoundUI == sound)
            {
                _audioSourceUI.clip = sfxNote.AudioClip;
                _audioSourceUI.Play();
                return;
            }
        }
    }

    public void PlaySFX(SFXTypeEvents sound)
    {
        foreach (var sfxNote in _audioEventsSFX)
        {
            if (sfxNote.SoundEvent == sound)
            {
                _audioSourceEvents.clip = sfxNote.AudioClip;
                _audioSourceEvents.Play();
                return;
            }
        }
    }

    public void MuteSFX()
    {
        _audioSourceItems.mute = !_audioSourceItems.mute;
        _audioSourceCreatures.mute = !_audioSourceCreatures.mute;
        _audioSourceUI.mute = !_audioSourceUI.mute;
        _audioSourceEvents.mute = !_audioSourceEvents.mute;
    }

    public void StopSFX(AudioSource audioSource)
    {
        audioSource.Stop();
    }
    public void StopSFX()
    {
        _audioSourceItems.Stop();
        _audioSourceCreatures.Stop();
        _audioSourceUI.Stop();
        _audioSourceEvents.Stop();
    }
}
