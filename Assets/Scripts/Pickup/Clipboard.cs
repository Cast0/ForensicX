using System.Collections;
using UnityEngine;

public class Clipboard : Interactable
{
    bool displayed = false;
    bool isOnHand = false;

    [SerializeField] Pickupable pickupable;
    [SerializeField] GameObject clipboardPanel, openCloseHint;
    [SerializeField] Vector3 positionOffset, rotationOffset;
    [SerializeField] Vector3 checklistPosition, checklistRotation;

    // Coroutine reference to handle cancellation
    Coroutine lerpCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        // Use proper event handling to avoid memory leaks
        InputManager.instance.F_action += OnFPressed;
        InputManager.instance.G_Input += DisableChecklist;

        SetChecklistDisplay(false);
        openCloseHint.SetActive(false);
    }

    private void SetChecklistDisplay(bool value)
    {
        if (clipboardPanel == null || clipboardPanel.activeSelf == value) return;

        clipboardPanel.SetActive(value);
        displayed = value;

        InteractionEvents.instance?.checklistDisplayed?.Invoke(value);
        Cursor.visible = value;
        Cursor.lockState = value ? CursorLockMode.None : CursorLockMode.Locked;
    }

    private void DisableChecklist()
    {
        if (pickupable == null || !pickupable.canDrop)
        {
            isOnHand = false;
            SetChecklistDisplay(false);
            openCloseHint.SetActive(false);
        }
    }

    private IEnumerator LerpToTargetAsync(Vector3 targetPosition, Vector3 targetRotation)
    {
        float lerpTime = 1f; // Adjust the time as needed
        float elapsedTime = 0f;

        Vector3 initialPosition = transform.localPosition;
        Vector3 initialRotation = transform.localRotation.eulerAngles;

        while (elapsedTime < lerpTime)
        {
            if (lerpCoroutine == null) yield break; // Check for cancellation

            transform.localPosition = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / lerpTime);
            transform.localRotation = Quaternion.Euler(Vector3.Lerp(initialRotation, targetRotation, elapsedTime / lerpTime));

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = targetPosition;
        transform.localRotation = Quaternion.Euler(targetRotation);

        lerpCoroutine = null; // Reset coroutine reference
    }

    private void OnFPressed()
    {
        if (!isOnHand || lerpCoroutine != null) return;

        if (!displayed)
        {
            lerpCoroutine = StartCoroutine(LerpToTargetAsync(checklistPosition, checklistRotation));
            SetChecklistDisplay(true);
        }
        else
        {
            SetChecklistDisplay(false);
            lerpCoroutine = StartCoroutine(LerpToTargetAsync(positionOffset, rotationOffset));
        }

        pickupable.canDrop = !displayed;

        // Use WaitForSeconds to wait for the coroutine to finish
        StartCoroutine(WaitForCoroutine());
    }

    private IEnumerator WaitForCoroutine()
    {
        yield return new WaitUntil(() => lerpCoroutine == null);
        // Continue with any actions that should happen after the coroutine completes
    }

    protected override void Interact()
    {
        isOnHand = true;
        transform.localPosition = positionOffset;
        transform.localRotation = Quaternion.Euler(rotationOffset);
        openCloseHint.SetActive(true);
    }
}
