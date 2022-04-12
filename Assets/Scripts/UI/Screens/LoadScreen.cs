using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadScreen : Screen
{
    [SerializeField] private TextMeshProUGUI _progressTxt;
    [SerializeField] private Image _loadingCircle;
    
    
    public void SetProgress(float progress)
    {
        _progressTxt.text = (int)(progress * 100) + "%";
        _loadingCircle.fillAmount += progress;
    }
}
