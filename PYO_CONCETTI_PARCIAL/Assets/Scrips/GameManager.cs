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

    public int temp = 0;

    public bool gameplayStar;

    private void OnEnable()
    {
        timer.onEnd += OnEndTime;
    }
    void Start()
    {
        // timer = new Timer(uiManager.TimerText, baseCountdownTime);
        timer.GetStuff(uiManager.TimerText, baseCountdownTime);
        gameplayStar = false;
    }
    
    public void OnClick() {
        temp++;
        Debug.Log(temp);


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

        timer.ResetTimer();

    }

}