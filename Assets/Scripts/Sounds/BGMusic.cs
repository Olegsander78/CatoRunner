using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : Sounds
{
    [SerializeField] private List<AudioSource> _audioSourcesBGMusic;
    [SerializeField] private AudioSource _currentAudioSourcesBGMusic;
}
