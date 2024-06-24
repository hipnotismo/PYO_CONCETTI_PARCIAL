using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TMP_Text instructionText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text timerText;

    [Header("Buttons")]
    [SerializeField] private GameObject mainButton;
    [SerializeField] private GameObject adButton;
    [SerializeField] private GameObject creditButton;

    [Header("Canvases")]
    [SerializeField] private GameObject adCanvas;
    [SerializeField] private GameObject creditCanvas;

    public TMP_Text TimerText;
    public TMP_Text ScoreText;
    public TMP_Text HighScoreText;

    private bool hasWatchedAd = false;

    void Awake()
    {
        TimerText = timerText;
        ScoreText = scoreText;
        HighScoreText = highScoreText;
        adButton.SetActive(false);
#if UNITY_ANDROID
        adButton.SetActive(true);
       
#endif

    }

    public void ShowInstructions(bool state)
    {
        instructionText.gameObject.SetActive(state);
    }

    public void ShowCredits(GameManager gameManager)
    {
        if (gameManager.gameplayStar == false)
        {
            CloseAndOpenCanvas(creditCanvas);
        }
    }

    public void ShowAds(GameManager gameManager)
    {
        if(gameManager.gameplayStar == false)
        {
            CloseAndOpenCanvas(adCanvas);
        }
    }

    public void CloseAndOpenCanvas(GameObject canvas)
    {
        if (canvas.activeSelf)
        {
            canvas.SetActive(false);
        }
        else
        {
            canvas.SetActive(true);
        }
    }

    public void EnableMainButton(bool state)
    {
        mainButton.SetActive(state);
    }

    public void OnOpenAndCloseAds(GameManager gameManager)
    {
        if (gameManager.gameplayStar || hasWatchedAd) return;

        CloseAndOpenCanvas(adCanvas);
    }

    public void OnChooseToWatchAd()
    {
        hasWatchedAd = true;
    }

    public void ResetAdsCanvas()
    {
        hasWatchedAd = false;
    }
}
