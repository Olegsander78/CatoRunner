using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelPopUpScreen : Screen
{
    [SerializeField] private Button _closeBtn;

    public TextMeshProUGUI TextLevelPopUp;

    private void Start()
    {
        _closeBtn.onClick.AddListener(ClosePopUp);
    }

    public void ClosePopUp()
    {
        GameController.Instance.SoundController.PlaySound(SFX.SFXTypeUI.ClickButton);
        GameController.Instance.ScreenController.PopScreen();
        GameController.Instance.ScreenController.PushScreen<SelectLevelsScreen>();
    }

    public void SetText(string Text)
    {
        TextLevelPopUp.text = Text;
    }

    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 1)
            GameObject.Find("_Player").GetComponentInChildren<PlayerController>().enabled = false;
    }

    private void OnDisable()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 1)
            GameObject.Find("_Player").GetComponentInChildren<PlayerController>().enabled = true;
    }
}
