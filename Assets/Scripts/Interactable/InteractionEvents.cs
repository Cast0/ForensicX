using UnityEngine.Events;
using UnityEngine;
using System;

public class InteractionEvents : MonoBehaviour
{
    public UnityEvent onInteract;
    public Action<bool> checklistDisplayed;
    public UnityEvent DeadBodyInteracted;
    public UnityEvent DeadBodyLeft;
    public UnityEvent exitDoor;
    public static InteractionEvents instance;
    private void Awake()
    {
        instance = this;
    }
}