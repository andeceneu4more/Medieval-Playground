using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerControler : MonoBehaviour
{
    public Text timerText;
    private float startTime;

    /// <summary>
    /// Set timer to start from the begging of the session
    /// </summary>
    public void SetStartTime(float newStart)
    {
        startTime = newStart;
    }

    /// <summary>
    /// Get the begging of session
    /// </summary>
    public float GetStartTime()
    {
        return startTime;
    }

    /// <summary>
    /// Display the timer in minutes and seconds
    /// </summary>
    void Update()
    {
        float time = Time.time - startTime;
        string minutes = ((int)time / 60).ToString();
        string seconds = (time % 60).ToString("f0");
        timerText.text = minutes + "'" + seconds + '"';
    }
}
