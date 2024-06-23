using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    private TMP_Text highScoreText;
    private string HighScoreKey = "highScoreKey";
    private int highScore;

    public void GetParameters(TMP_Text _highScoreText)
    {
        highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        highScoreText = _highScoreText;
        UpdateText(highScore);
    }

    private void UpdateText(int highScore)
    {
        highScoreText.text = "High Score: " + highScore.ToString("D2");
    }

    public void IsHighScore(int score)
    {
        if (score > highScore)
        {
            highScore = score;
            SetHighScore();
        }

    }

    private void SetHighScore()
    {
        PlayerPrefs.SetInt(HighScoreKey, highScore);
        PlayerPrefs.Save();

        UpdateText(highScore);
    }
}
