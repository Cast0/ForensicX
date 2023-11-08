using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Clipboard : Interactable
{
    bool displayed = false;
    [SerializeField] GameObject clipboardPanel;
    [SerializeField] Vector3 positionOffset, rotationOffset;
    [SerializeField] Vector3 checklistPosition, checklistRotation;
    // Start is called before the first frame update
    void Start()
    {
        InputManager.instance.F_action += OnFPressed;
        InputManager.instance.G_Input += DisableChecklist;
        SetChecklistDisplay(false);

    }
    private void SetChecklistDisplay(bool value)
    {
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
    private void DisableChecklist()
    {
        // Debug.Log("Drop Item");

        if (displayed)
        {

            SetChecklistDisplay(false);


        }
    }

    private async void OnFPressed()
    {

        if (!Player_HandStatus.clipBoardIOnHand) return;
        if (!displayed)
        {

            await LerpToTargetAsync(checklistPosition, checklistRotation);

            SetChecklistDisplay(true);

            return;

        }
        if (displayed)
        {
            SetChecklistDisplay(false);
            await LerpToTargetAsync(positionOffset, rotationOffset);

            return;
        }
        // transform.localPosition = checklistPosition;
        // transform.localRotation = Quaternion.Euler(checklistRotation);
    }



    private float lerpSpeed = 5.5f;

    private async Task LerpToTargetAsync(Vector3 targetPos, Vector3 targetRot)
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

    }
}
