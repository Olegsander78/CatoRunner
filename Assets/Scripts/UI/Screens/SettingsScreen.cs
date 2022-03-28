using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScreen : Screen
{
    [SerializeField] public Toggle _soundTgl;
    [SerializeField] public Slider _volumeSld;    
    [SerializeField] public Button _backBtn;


    private void Start()
    {
        _backBtn.onClick.AddListener(GoBackMainMenu);
    }

    public void OnSound()
    {

    }

    public void AddVolume()
    {

    }

    public void GoBackMainMenu()
    {
        GameController.Instance.ScreenController.PushScreen<MainMenuScreen>();
    }

}
