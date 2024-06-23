using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float baseCountdownTime = 3f;
    [SerializeField] private float waitToRestart = 2f;

    [Header("UI Manager")]
    [SerializeField] UIManager uiManager;

    [SerializeField] Timer timer;
    [SerializeField] Clicks clicks;

    public bool gameplayStar;

    private void OnEnable()
    {
        timer.onEnd += OnEndTime;
    }

    private void OnDisable()
    {
        timer.onEnd -= OnEndTime;
    }
    void Start()
    {
        clicks.GetParameters(uiManager.ScoreText);
        timer.GetParameters(uiManager.TimerText, baseCountdownTime);
        gameplayStar = false;
    }
    
    public void OnClick() {

        clicks.OnClick();
        if (gameplayStar) return;
        
        uiManager.ShowInstructions(false);
        timer.TimeStart();
        gameplayStar = true;


    }

    public void OnEndTime()
    {
        uiManager.EnableMainButton(false);
        StartCoroutine(DelayRestart());

    }

    private IEnumerator DelayRestart()
    {
        yield return new WaitForSeconds(waitToRestart);
        ResetGame();
    }

    private void ResetGame()
    {
        gameplayStar = false;

        uiManager.ShowInstructions(true);
        uiManager.EnableMainButton(true);
        clicks.ResetClicks();

        timer.ResetTimer();

    }

}