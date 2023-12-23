using System.Collections;
using System.Collections.Generic;
using DanielLochner.Assets.SimpleScrollSnap;
using UnityEngine;

public class ChecklistManager : MonoBehaviour
{
    public List<Checklist> checklist;

    public ChecklistHandler checklistHandler;
    [SerializeField] SimpleScrollSnap simpleScrollSnap;

    private void Start()
    {
        ChecklistItemRecord.strikedItems = new();
        
        // Start a coroutine to load the checklists asynchronously
        LoadCheckList();
    }

    private void LoadCheckList()
    {
        foreach (var item in checklist)
        {

            GameObject g0 = simpleScrollSnap.AddToFront(checklistHandler.gameObject);
            g0.GetComponent<ChecklistHandler>().Setup(item);
            g0.SetActive(true);
        }
    }
}
