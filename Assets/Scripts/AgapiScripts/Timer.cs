using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTimeInSeconds = 3600; // Set the total time in seconds (1 hour in this example)
    private float currentTimeInSeconds;

    public TextMeshProUGUI timerText;
    bool canTime = true;
    private void Start()
    {
        currentTimeInSeconds = totalTimeInSeconds;
        UpdateTimerDisplay();
    }

    private void Update()
    {
        if (!canTime) return;
        if (currentTimeInSeconds > 0)
        {
            currentTimeInSeconds -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {

            Debug.Log("Timer Finished!");
        }
    }
    public void StopCount()
    {
        canTime = true;
    }

    private void UpdateTimerDisplay()
    {
        int hours = Mathf.FloorToInt(currentTimeInSeconds / 3600);
        int minutes = Mathf.FloorToInt((currentTimeInSeconds % 3600) / 60);
        int seconds = Mathf.FloorToInt(currentTimeInSeconds % 60);

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
}
