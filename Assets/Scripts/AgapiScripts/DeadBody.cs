using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class DeadBody : Interactable
{
    // Start is called before the first frame update
    [SerializeField] CinemachineVirtualCamera virtualCam;
    [SerializeField] PlayerUI playerUI;
    [SerializeField] Transform inspectPosition;

    [SerializeField] GameObject deadBodyInspect;
    [SerializeField] Transform[] jointsToRotate;
    [SerializeField] Collider collider;
    Transform prevFollow;
    private float rotationSpeed = 2;
    private void Start()
    {

    }

    public void RotateLeft()
    {
        Debug.Log("Rotating Left");

    }
    public void RotateRight()
    {
        Debug.Log("Rotating Right");

    }

    public void LeaveInspection() // this is attached to a button 
    {
        InteractionEvents.instance.DeadBodyInteracted?.Invoke(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        virtualCam.Follow = prevFollow;
        deadBodyInspect?.SetActive(false);
        collider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void Interact()
    {
        collider.enabled = false;

        playerUI.ClearUI();
        prevFollow = virtualCam.Follow;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        virtualCam.Follow = inspectPosition;
        InteractionEvents.instance.DeadBodyInteracted?.Invoke(true);
        deadBodyInspect?.SetActive(true);

    }
}
