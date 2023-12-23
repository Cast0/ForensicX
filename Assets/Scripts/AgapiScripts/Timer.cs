using System.Collections;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer instance = null;

    [SerializeField] private TextMeshProUGUI timerDisplay;
    private Coroutine countdownCoroutine;
    private Coroutine blinkingCoroutine;
    [SerializeField] float countdownTimeInSeconds = 180; // 5 minutes
    private bool isCountdownFinished = false;
    bool blinkText = true;

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
        blinkText = false;
        if (blinkingCoroutine != null)
        {
            StopCoroutine(blinkingCoroutine);
            blinkingCoroutine = null;
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
        blinkingCoroutine = StartCoroutine(BlinkText());



    }
    IEnumerator BlinkText()
    {
        timerDisplay.color = Color.red;
        timerDisplay.text = "Timer Finished!";
        while (blinkText)
        {

            yield return new WaitForSeconds(.5f);
            timerDisplay.gameObject.SetActive(false);

            yield return new WaitForSeconds(.5f);
            timerDisplay.gameObject.SetActive(true);
        }



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
