using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public static ScoreSystem instance = null;
    [SerializeField] GameObject scorePanel;
    [SerializeField] GameObject exitButton;
    [SerializeField] ScoreItem[] scoreItems;
    [SerializeField] TextMeshProUGUI totalScore;
    bool submitted = false;
    int totalScoreInt = 0;
    public SceneLoader sceneLoader;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        InteractionEvents.instance.exitDoor += DisplayScore;
        scorePanel.SetActive(false);
        totalScore.gameObject.SetActive(false);
        foreach (var item in scoreItems)
        {
            item.gameObject.SetActive(false);
        }
        exitButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LeaveCase()
    {
        SceneLoader.instance?.LoadScene(0);
        totalScore.gameObject.SetActive(false);
        foreach (var item in scoreItems)
        {
            item.gameObject.SetActive(false);
        }
        exitButton.SetActive(false);
    }
    public void EvaulateInspection(string _caseWoundType)
    {
        scoreItems[0].messageText.text = "Case Wound Type";
        scoreItems[1].messageText.text = "Wounds Inspection";
        scoreItems[2].messageText.text = "Wounds Inspection Proper";
        scoreItems[3].messageText.text = "Submitted On Time";
        submitted = true;


        int score = 0;


        Debug.Log(string.Format("{0} is equal to {1}: {2}", _caseWoundType.ToLower(), CaseManager.instance.caseWoundType.ToLower(), _caseWoundType.ToLower() == CaseManager.instance.caseWoundType.ToLower()));

        if (_caseWoundType.ToLower() == CaseManager.instance.caseWoundType.ToLower())
        {

            scoreItems[0].checkMark.SetActive(true);
            score += 25;
        }

        if (CaseManager.instance.isWoundsCompleted())
        {
            scoreItems[1].checkMark.SetActive(true);
            score += 25;
        }

        if (CaseManager.instance.isRightProcedure)
        {
            scoreItems[2].checkMark.SetActive(true);
            score += 25;
        }
        if (!Timer.instance.IsCountdownFinished())
        {
            scoreItems[3].checkMark.SetActive(true); score += 25;
        }

        totalScoreInt = score;
        Debug.Log("Evaluation done");
    }

    public void DisplayScore()
    {
        if (!submitted) { LeaveCase(); return; }
        Debug.Log("Display Score");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        scorePanel.SetActive(true);
        StartCoroutine(SequenceDisplay());
    }
    IEnumerator SequenceDisplay()
    {
        foreach (var item in scoreItems)
        {
            item.gameObject.SetActive(true);

            yield return new WaitForSeconds(0.5f);

        }
        float counter = 0;
        var delay = new WaitForSeconds(0.005f);
        totalScore.gameObject.SetActive(true);
        while (counter < totalScoreInt)
        {

            counter += 1;
            totalScore.text = counter.ToString("0");
            yield return delay;

        }


        exitButton.SetActive(true);
        yield return null;

    }
}
