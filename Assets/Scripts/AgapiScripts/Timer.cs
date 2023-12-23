using System.Collections;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer instance = null;

    [SerializeField] private TextMeshProUGUI timerDisplay;
    [SerializeField] float countdownTimeInSeconds = 180; // 3 minutes
    private Coroutine countdownCoroutine;
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
        }

        timerDisplay.gameObject.SetActive(false);
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

        isCountdownFinished = true;
        StartCoroutine(BlinkText());
    }

    IEnumerator BlinkText()
    {
        Color originalColor = timerDisplay.color;
        timerDisplay.color = Color.red;
        timerDisplay.text = "Timer Finished!";

        while (isCountdownFinished)
        {
            yield return new WaitForSeconds(0.5f);
            timerDisplay.gameObject.SetActive(!timerDisplay.gameObject.activeSelf);
        }

        // Reset the color and set the text to an empty string when not blinking
        timerDisplay.color = originalColor;
        timerDisplay.text = "";
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
