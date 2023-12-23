<<<<<<< Updated upstream
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEditor.Search;
=======
using Cinemachine;
>>>>>>> Stashed changes
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
<<<<<<< Updated upstream
    public LayerMask InteractableLayerMask = 6;
    private PlayerUI PlayerUI;
=======
    [SerializeField] private pickanddropscripttest pickAndDrop;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private LayerMask interactableLayerMask = 6;

    private bool canInteract = true;
    [SerializeField] PlayerUI playerUI;
    private Interactable interactable;
    private Pickupable pickupable;
>>>>>>> Stashed changes

    void Start()
    {
<<<<<<< Updated upstream
        PlayerUI = GetComponent<PlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerUI.UpdateText(string.Empty);
        PlayerUI.UpdateDescriptionText(string.Empty);
        PlayerUI.Descriptionhide();
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 3, InteractableLayerMask))
        {
            if (hit.collider.GetComponent<Interactable>() != null)
            {
                Interactable Interactable = hit.collider.GetComponent<Interactable>();
                PlayerUI.UpdateText(Interactable.PromptMessage);
                PlayerUI.UpdateDescriptionText(Interactable.Descriptiontext);
                PlayerUI.Descriptionshow();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Interactable.BaseInteract();
                }
            }
=======
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
>>>>>>> Stashed changes
        }
    }
}
