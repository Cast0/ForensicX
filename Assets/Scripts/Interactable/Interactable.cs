using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Interactable : MonoBehaviour
{
    //add or remove an interaction event component to this game object.
    public bool useEvents;
    //message displayed to player when looking at an interactable
    public string PromptMessage;
    public string Descriptiontext;
    // Start is called before the first frame update
    // public PlayerInteract playerInteract1;

    public void BaseInteract()
    {

        // if (useEvents)
        //     GetComponent<InteractionEvents>().onInteract.Invoke();
        Interact();



    }
    protected virtual void Interact()
    {
        // we wont have any code written in this function
        // this is a template function to be overridden by our subclass
    }
}