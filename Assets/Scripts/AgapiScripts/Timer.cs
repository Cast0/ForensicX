using System.Collections;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer instance = null;

    [SerializeField] private TextMeshProUGUI timerDisplay;
    private Coroutine countdownCoroutine;
    private float countdownTimeInSeconds = 180; // 5 minutes
    private bool isCountdownFinished = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCountdown();
    }

    public void StartCountdown()
    {
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }

        countdownCoroutine = StartCoroutine(Countdown());
    }

    public bool IsCountdownFinished()
    {
        return isCountdownFinished;
    }

    public void StopCount()
    {
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
            countdownCoroutine = null;
            timerDisplay.gameObject.SetActive(false);
        }
    }

    IEnumerator Countdown()
    {
        float currentTime = countdownTimeInSeconds;

        while (currentTime > 0)
        {
            UpdateTimerDisplay(currentTime);
            yield return new WaitForSeconds(1);
            currentTime--;
        }

        // Countdown finished
        isCountdownFinished = true;
        UpdateTimerDisplay(0);
        timerDisplay.text = "Timer Finished!";
    }

    private void UpdateTimerDisplay(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        int hours = Mathf.FloorToInt(timeInSeconds / 3600);

        string timerText = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
        timerDisplay.text = timerText;
    }
}
