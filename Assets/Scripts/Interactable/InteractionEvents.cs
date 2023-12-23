using UnityEngine.Events;
using UnityEngine;
using System;
using System.Collections.Generic;

public class InteractionEvents : MonoBehaviour
{
    // public UnityEvent onInteract;
    public Action<bool> checklistDisplayed;
    public Action<bool> LaptopInteracted;
    public Action<bool> DeadBodyInteracted;

    // public UnityEvent DeadBodyInteracted;
    // public UnityEvent DeadBodyLeft;
    public Action<List<ChecklistItem>> ReportSubmitted;
    public Action<bool> CameraChangeInteract;
    public Action exitDoor;
    public Action ContinuePlaying;

    public static InteractionEvents instance = null;
    private void Awake()
    {
        instance = this;
    }
}