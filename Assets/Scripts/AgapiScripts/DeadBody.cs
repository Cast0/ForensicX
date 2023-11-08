using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class DeadBody : Interactable
{
    // Start is called before the first frame update
    [SerializeField] CinemachineVirtualCamera virtualCam;
    [SerializeField] Transform inspectPosition;
    [SerializeField] Vector3 leftRot, rightRot;
    [SerializeField] GameObject deadBodyInspect;
    [SerializeField] Transform[] jointsToRotate;
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
 
    public void LeaveInspection()
    {
        InteractionEvents.instance.DeadBodyLeft?.Invoke();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        virtualCam.Follow = prevFollow;
        deadBodyInspect?.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void Interact()
    {

        prevFollow = virtualCam.Follow;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        virtualCam.Follow = inspectPosition;
        InteractionEvents.instance.DeadBodyInteracted?.Invoke();
        deadBodyInspect?.SetActive(true);

    }
}
