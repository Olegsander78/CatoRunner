using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroScreen : Screen
{
    [SerializeField] private Button _playBtn;

    private void Start()
    {
        _playBtn.onClick.AddListener(Play);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
