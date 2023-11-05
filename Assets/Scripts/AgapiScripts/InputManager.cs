using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public Action playerInteract;
    public Action openItem;
    public Action G_Input;
    public Action F_action;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) playerInteract?.Invoke(); // trigger the player iteraction call
        if (Input.GetKeyDown(KeyCode.Space)) openItem?.Invoke();
        if (Input.GetKeyDown(KeyCode.G)) G_Input?.Invoke();
        if (Input.GetKeyDown(KeyCode.F)) F_action?.Invoke();


    }
}
