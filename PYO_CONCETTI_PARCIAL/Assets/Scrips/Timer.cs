using System.Collections;
using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TMP_Text timerText;
    private float countdown;
    private float baseCountdown;

    public event Action onEnd = delegate { };

    public void GetStuff(TMP_Text _timerText, float _baseCountdown)
    {
        timerText = _timerText;
        baseCountdown = _baseCountdown;
        countdown = baseCountdown;
    }
    public void TimeStart()
    {
        StartCoroutine(CountdownTimer());
    }

    private IEnumerator CountdownTimer()
    {
        float timer = countdown;

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            UpdateTimerText(timer);
            yield return null;
        }

        UpdateTimerText(0f);
        onEnd?.Invoke();
    }

    private void UpdateTimerText(float timer)
    {
        int seconds = Mathf.FloorToInt(timer);
        int milliseconds = Mathf.FloorToInt((timer - seconds) * 100);
        timerText.text = $"Time: {seconds:D2}:{milliseconds:D2}";
    }

    public void ResetTimer()
    {
       
        StopCoroutine(CountdownTimer());
        countdown = baseCountdown;
        UpdateTimerText(countdown);
    }
}
