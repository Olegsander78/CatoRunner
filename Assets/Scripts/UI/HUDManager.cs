using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private int _scoreTotal;

    public TextMeshProUGUI ScoreText;


    private void Start()
    {
        UpdateScoreText();
        UpdateHealthView();
    }

    public void AddScore(int amount)
    {
        _scoreTotal += amount;
        UpdateScoreText();
    }

    public void AddHealth(int amount)
    {
        
        UpdateHealthView();
    }

    public void AddSpeedUp()
    {

    }

    public void AddInvulnerability()
    {

    }

    public void UpdateScoreText()
    {
        ScoreText.text = _scoreTotal.ToString();
    }

    public void UpdateHealthView()
    {

    }

}
