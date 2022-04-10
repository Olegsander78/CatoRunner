using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadScreen : Screen
{
    [SerializeField] private TextMeshProUGUI _progressTxt;
    public void SetProgress(float progress)
    {
        _progressTxt.text = (int)(progress * 100) + "%";
    }
}
