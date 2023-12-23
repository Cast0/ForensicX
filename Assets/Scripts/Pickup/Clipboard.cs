using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Clipboard : Interactable
{
    bool displayed = false;
    [SerializeField] Pickupable pickupable;
    [SerializeField] GameObject clipboardPanel, openCloseHint;
    [SerializeField] Vector3 positionOffset, rotationOffset;
    [SerializeField] Vector3 checklistPosition, checklistRotation;
    // Start is called before the first frame update
    void Start()
    {
        InputManager.instance.F_action += OnFPressed;
        InputManager.instance.G_Input += DisableChecklist;
        SetChecklistDisplay(false);
        pickupable.canDrop = true;
        openCloseHint.SetActive(false);
    }
    private void SetChecklistDisplay(bool value)
    {

        if (clipboardPanel.activeSelf == value) return; // if the clipaboard is already active and is being reactivated, it will return
        clipboardPanel.SetActive(value);

        displayed = value;
        InteractionEvents.instance.checklistDisplayed?.Invoke(value);
        Cursor.visible = value;
        if (value) Cursor.lockState = CursorLockMode.None;
        else Cursor.lockState = CursorLockMode.Locked;


    }
    public void DeadBodyInteracted()
    {
        if (displayed)
        {

            SetChecklistDisplay(false);
        }
    }

    private void DisableChecklist()// this is when g is pressed meaning to drop the clipboard
    {
        // Debug.Log("Drop Item");

        if (displayed)
        {


            SetChecklistDisplay(false);


        }
        openCloseHint.SetActive(false); // this is force disable since it wont depend if the checklist is displayed or not, rather only depend when clipabord is on hand
    }

    private async void OnFPressed()
    {


        if (!displayed)
        {
            pickupable.canDrop = false; // drop not allowed for clipabord because it wills tart playign animation
            await LerpToTargetAsync(checklistPosition, checklistRotation);

            SetChecklistDisplay(true);



        }
        else
        {
            SetChecklistDisplay(false);
            await LerpToTargetAsync(positionOffset, rotationOffset);
            pickupable.canDrop = true;// drop only allowed for clipabord if animation done

        }

        // transform.localPosition = checklistPosition;
        // transform.localRotation = Quaternion.Euler(checklistRotation);
    }



    private float lerpSpeed = 5.5f;


    private async Task LerpToTargetAsync(Vector3 targetPos, Vector3 targetRot) // something like move the clipboard to display nad undisplay the chcecklist
    {
        Vector3 initialPosition = transform.localPosition;
        Quaternion initialRotation = transform.localRotation;
        float elapsedTime = 0f;

        while (elapsedTime < .5f)
        {
            // Calculate t (time) based on elapsedTime and lerpSpeed
            float t = elapsedTime * lerpSpeed;

            // Lerp position
            transform.localPosition = Vector3.Lerp(initialPosition, targetPos, t);

            // Lerp rotation
            transform.localRotation = Quaternion.Slerp(initialRotation, Quaternion.Euler(targetRot), t);

            await Task.Yield();

            elapsedTime += Time.deltaTime;
        }

        // Ensure that the final position and rotation are exactly the target values
        transform.localPosition = targetPos;
        transform.localRotation = Quaternion.Euler(targetRot);
    }



    protected override void Interact()
    {
        transform.localPosition = positionOffset;
        transform.localRotation = Quaternion.Euler(rotationOffset);
        openCloseHint.SetActive(true);

    }
}