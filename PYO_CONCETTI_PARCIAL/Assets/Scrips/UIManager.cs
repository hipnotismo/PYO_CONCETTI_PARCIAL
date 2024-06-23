using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] TMP_Text instructionText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text timerText;

    [Header("Buttons")]
    [SerializeField] GameObject addButton;
    [SerializeField] GameObject creditButton;

    [Header("Canvases")]
    [SerializeField] GameObject addCanvas;
    [SerializeField] GameObject creditCanvas;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
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
}
