using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TMP_Text instructionText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timerText;

    [Header("Buttons")]
    [SerializeField] private GameObject mainButton;
    [SerializeField] private GameObject addButton;
    [SerializeField] private GameObject creditButton;

    [Header("Canvases")]
    [SerializeField] private GameObject addCanvas;
    [SerializeField] private GameObject creditCanvas;

    public TMP_Text TimerText ;

    void Awake()
    {
        TimerText = timerText;
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

    public void ShowRewards(GameManager gameManager)
    {
        if(gameManager.gameplayStar == false)
        {
            CloseAndOpenCanvas(addCanvas);
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
}
