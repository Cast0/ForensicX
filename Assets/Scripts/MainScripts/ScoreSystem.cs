using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{

    [SerializeField] GameObject NoSubmitExitPrompt;
    [SerializeField] GameObject scorePanel;
    [SerializeField] GameObject exitButton;
    [SerializeField] ScoreItem[] scoreItems;
    [SerializeField] TextMeshProUGUI totalScore;
    bool submitted = false;
    int totalScoreInt = 0;
    // public SceneLoader sceneLoader;

    private void OnDisable()
    {
        InteractionEvents.instance.ReportSubmitted -= EvaulateInspection;
    }
    void Start()
    {
        InteractionEvents.instance.ReportSubmitted += EvaulateInspection;
        NoSubmitExitPrompt?.SetActive(false);
        InteractionEvents.instance.exitDoor += DisplayScore;
        scorePanel.SetActive(false);
        totalScore.gameObject.SetActive(false);
        foreach (var item in scoreItems)
        {
            item.gameObject.SetActive(false);
        }
        exitButton.SetActive(false);
    }
    public void Yes_KeepPlaying()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        NoSubmitExitPrompt?.SetActive(false);
        InteractionEvents.instance.ContinuePlaying?.Invoke();
    }
    public void No_Exit()
    {
        totalScore.gameObject.SetActive(false);
        scorePanel.SetActive(false);
        foreach (var item in scoreItems)
        {
            item.gameObject.SetActive(false);
        }
        exitButton.SetActive(false);
        SceneLoader.instance?.LoadScene(1);

    }
    public void LeaveCase()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        NoSubmitExitPrompt?.SetActive(true);

    }


    public void EvaulateInspection(List<ChecklistItem> submittedItems)
    {
        string woundTypes = string.Empty;

        for (int i = 0; i < submittedItems.Count; i++)
        {
            if (i > 0) woundTypes += ", ";
            woundTypes += submittedItems[i].itemName;
        }

        scoreItems[0].messageText.text = "Case Wound Type: " + woundTypes.ToUpper();
        string woundString = CaseManager.instance.GetWoundCount().ToString() + "/" + CaseManager.instance.totalWounds.ToString();
        scoreItems[1].messageText.text = "Wounds Inspected\n  " + woundString;
        scoreItems[2].messageText.text = "Proper Inspection";
        scoreItems[3].messageText.text = "Submitted On Time";
        submitted = true;


        int score = 0;




        if (AreUnorderedListsEqual<ChecklistItem>(submittedItems, CaseManager.instance.caseItems))
        {
            Debug.Log("Correct case types");
            scoreItems[0].checkMark.SetActive(true);
            score += 25;
        }

        if (CaseManager.instance.isWoundsCompleted())
        {
            scoreItems[1].checkMark.SetActive(true);
            score += 25;
        }

        if (RightProcedure())
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


    bool AreUnorderedListsEqual<T>(List<T> list1, List<T> list2)
    {

        // Check if list coutn is not equal
        if (list1.Count != list2.Count)
        {
            return false;
        }
        foreach (var item in list1)
        {
            if (!list2.Contains(item))
            {
                return false;
            }
        }
        return true;

    }
    private bool RightProcedure()
    {


        if (!CaseManager.instance.IsBookRead()) return false;
        if (!CaseManager.instance.IsNoteRead()) return false;

        foreach (var item in CaseManager.instance.caseItems)
        {
            if (!ChecklistItemRecord.strikedItems.Contains(item)) return false;
        }
        return true;
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

        if (totalScoreInt >= 75 && CaseData.currentCaseOpened == PlayerPrefs.GetInt("caseUnlocked", 1)) PlayerPrefs.SetInt("caseUnlocked", PlayerPrefs.GetInt("caseUnlocked", 1) + 1);
        exitButton.SetActive(true);
        yield return null;

    }
}
