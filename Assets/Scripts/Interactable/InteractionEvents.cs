using UnityEngine.Events;
using UnityEngine;
using System;

public class InteractionEvents : MonoBehaviour
{
    // public UnityEvent onInteract;
    public Action<bool> checklistDisplayed;
    public Action<bool> LaptopInteracted;
    public Action<bool> DeadBodyInteracted;
    // public UnityEvent DeadBodyInteracted;
    // public UnityEvent DeadBodyLeft;
    public Action exitDoor;
    public static InteractionEvents instance = null;
    private void Awake()
    {
        instance = this;
    }
}