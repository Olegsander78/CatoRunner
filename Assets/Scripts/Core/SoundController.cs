using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private List<Sounds> _soundsList;
    [SerializeField] private Sounds _initBGMusic;


    private void Awake()
    {
        foreach (var sounds in _soundsList)
        {
            sounds.gameObject.SetActive(false);
        }
        //_initBGMusic. ;
        DontDestroyOnLoad(this);
    }

    private void PlayBGMusic(int levelMusic)
    {
        //_soundsList[levelMusic].
    }
}


