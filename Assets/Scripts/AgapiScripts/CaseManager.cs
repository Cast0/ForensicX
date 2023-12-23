using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseManager : MonoBehaviour
{
    public string caseWoundType;
    public int totalWounds;
    bool bookRead = false;
    bool noteRead = false;
    public List<ChecklistItem> caseItems = new();
    public List<ChecklistItem> totalCaseItems = new();
    int currentWOundCount;
    // Start is called before the first frame update

    public static CaseManager instance = null;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        CaseData.submitted = false;
        currentWOundCount = 0;
    }

    public bool isWoundsCompleted()
    {
        return currentWOundCount >= totalWounds;
    }
    public void IncrementWoundCount()
    {
        if (CaseData.submitted) return;
        currentWOundCount++;
    }
    public void TriggerBookRead()
    {
        if (CaseData.submitted) return;
        bookRead = true;
    }
    public void TriggerNoteRead()
    {
        if (CaseData.submitted) return;
        noteRead = true;
    }
    public bool IsBookRead() => bookRead;
    public bool IsNoteRead() => noteRead;
    public int GetWoundCount()
    {
        return currentWOundCount;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
