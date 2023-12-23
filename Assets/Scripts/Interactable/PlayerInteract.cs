using Cinemachine;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private pickanddropscripttest pickAndDrop;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private LayerMask interactableLayerMask = 6;

    private bool canInteract = true;
    [SerializeField] PlayerUI playerUI;
    private Interactable interactable;
    private Pickupable pickupable;

    void Start()
    {
        InputManager.instance.playerInteract += OnInteract;
        InteractionEvents.instance.LaptopInteracted += SetCanInteract;
        InteractionEvents.instance.DeadBodyInteracted += SetCanInteract;
        InteractionEvents.instance.exitDoor += ExitDoor;
        InteractionEvents.instance.ContinuePlaying += OnContinuePlaying;

    }

    private void OnContinuePlaying()
    {
        canInteract = true;
    }

    public void SetCanInteract(bool value)
    {
        canInteract = !value;
    }

    public void ExitDoor()
    {
        canInteract = false;
    }

    private void OnInteract()
    {
        if (!canInteract || interactable == null) return;

        GameObject picked = interactable.gameObject;


        if (interactable.CompareTag("Pickable"))
        {
            Debug.Log("Picked up:" + interactable.name);
            pickAndDrop.Pickup(interactable.GetComponent<Pickupable>());
            // Player_HandStatus.triggerClipboard(picked);
        }

        interactable.BaseInteract();
        interactable.BaseInteract(virtualCamera);



    }

    void Update()
    {
        if (!canInteract) return;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 3, interactableLayerMask))
        {

            interactable = hit.collider.GetComponent<Interactable>();
            playerUI.Descriptionshow(interactable.Descriptiontext, interactable.PromptMessage);
        }
        else
        {
            interactable = null;
            playerUI.Descriptionhide();
        }
    }
}
