using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI PlayerHealthText;


    public void UpdateScoreText(int currentScore)
    {
        ScoreText.text = " Score: " + currentScore.ToString();
    }

    public void UpdateHealthView(int playerHealth)
    {
        PlayerHealthText.text = " Health: " + playerHealth.ToString();
    }

}
