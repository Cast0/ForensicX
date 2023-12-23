using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class WhiteBoard : Interactable
{
    // Start is called before the first frame update
    CinemachineVirtualCamera SelfVirtualCam = null;

    [SerializeField] Transform inspectPosition;

    [SerializeField] GameObject inspectCanvas;

    [SerializeField] Collider collider;
    Transform prevFollow;
    private void Start()
    {
        inspectCanvas?.SetActive(false);
    }



    public void LeaveInspection() // this is attached to a button 
    {
        InteractionEvents.instance.CameraChangeInteract?.Invoke(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SelfVirtualCam.Follow = prevFollow;
        inspectCanvas?.SetActive(false);
        collider.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void Interact(CinemachineVirtualCamera virtualCam)
    {
        InteractionEvents.instance.CameraChangeInteract?.Invoke(true);
        /*setup camera*/
        SelfVirtualCam = virtualCam;
        prevFollow = SelfVirtualCam.Follow;
        SelfVirtualCam.Follow = inspectPosition;
        /*setup camera*/
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        collider.enabled = false;
        inspectCanvas?.SetActive(true);

    }

}
