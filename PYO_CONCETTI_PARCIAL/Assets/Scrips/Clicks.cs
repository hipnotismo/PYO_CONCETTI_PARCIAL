using TMPro;
using UnityEngine;

public class Clicks : MonoBehaviour
{
    private TMP_Text scoreText;
    private int scoreCounter = 0;

    public void GetParameters(TMP_Text _scoreText)
    {
        scoreText = _scoreText;
    }

   public void OnClick()
    {
        scoreCounter++;
        UpdateScoreText();
    }

    public void ResetClicks()
    {
        scoreCounter = 0;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"{scoreCounter:D2} clicks";
#if UNITY_ANDROID
        clickCounterText.text = $"{scoreCounter:D2} taps";;
#endif
    }
}
