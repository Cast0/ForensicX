using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class DeadBody : Interactable
{
    // Start is called before the first frame update
    CinemachineVirtualCamera SelfVirtualCam = null;

    [SerializeField] Transform inspectPosition;

    [SerializeField] GameObject deadBodyInspect;
    [SerializeField] Transform[] jointsToRotate;
    [SerializeField] Collider collider;
    Transform prevFollow;
    private void Start()
    {
        deadBodyInspect?.SetActive(false);
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
        SelfVirtualCam.Follow = prevFollow;
        deadBodyInspect?.SetActive(false);
        collider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void Interact(CinemachineVirtualCamera virtualCam)
    {
        SelfVirtualCam = virtualCam;
        collider.enabled = false;

        // playerUI.ClearUI();
        prevFollow = SelfVirtualCam.Follow;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SelfVirtualCam.Follow = inspectPosition;
        InteractionEvents.instance.DeadBodyInteracted?.Invoke(true);
        deadBodyInspect?.SetActive(true);

    }
}
