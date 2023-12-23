using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clipboard : Interactable
{
<<<<<<< Updated upstream

    // Start is called before the first frame update
    void Start()
    {
=======
    bool displayed = false;
    bool isOnHand = false;
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

>>>>>>> Stashed changes

    }

<<<<<<< Updated upstream
    // Update is called once per frame
    void Update()
    {

=======
            SetChecklistDisplay(false);
        }
    }
    private void DisableChecklist()// this is when g is pressed meaning to drop the clipboard
    {
        // Debug.Log("Drop Item");

        if (pickupable.canDrop)
        {

            isOnHand = false;
            SetChecklistDisplay(false);
            openCloseHint.SetActive(false); // this is force disable since it wont depend if the checklist is displayed or not, rather only depend when clipabord is on hand

        }

    }

    private async void OnFPressed()
    {

        if (!isOnHand) return;
        if (!displayed)
        {

            await LerpToTargetAsync(checklistPosition, checklistRotation);
            SetChecklistDisplay(true);
            pickupable.canDrop = !displayed;

            return;

        }
        if (displayed)
        {
            SetChecklistDisplay(false);
            await LerpToTargetAsync(positionOffset, rotationOffset);
            pickupable.canDrop = !displayed;
            return;
        }
        // transform.localPosition = checklistPosition;
        // transform.localRotation = Quaternion.Euler(checklistRotation);
>>>>>>> Stashed changes
    }

    protected override void Interact()
    {
<<<<<<< Updated upstream
=======
        isOnHand = true;
        transform.localPosition = positionOffset;
        transform.localRotation = Quaternion.Euler(rotationOffset);
        openCloseHint.SetActive(true);
>>>>>>> Stashed changes

    }
}
