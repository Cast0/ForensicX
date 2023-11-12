using System;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] pickanddropscripttest pickAndDrop;
    // [SerializeField] Player_HandStatus player_HandStatus;
    bool canInteract = true;
    public LayerMask InteractableLayerMask = 6;
    private PlayerUI PlayerUI;
    Interactable interactable = null;
    GameObject picked1;

    // Start is called before the first frame update
    void Start()
    {
        InputManager.instance.playerInteract += OnInteract; // used event to only detect player input in one update method. Avoid using Update method as much as possible 
        InputManager.instance.G_Input += OnItemDrop;
        InteractionEvents.instance.LaptopInteracted += SetCanInteract;
        InteractionEvents.instance.DeadBodyInteracted += SetCanInteract;
        PlayerUI = GetComponent<PlayerUI>();
    }


    private void OnItemDrop()
    {

    }
    public void SetCanInteract(bool value)
    {
        canInteract = !value; // inverse the vvalue because true means laptop has been interacted and canInteract should be false and vice versa
    }
    private void OnInteract()
    {
        if (!canInteract) return;
        if (interactable == null) return;


        GameObject picked = interactable.gameObject;
        Debug.Log(picked.name);

        if (picked.tag == "Pickable")
        {
            pickAndDrop.Pickup(picked);

            Player_HandStatus.triggerClipboard(picked);
        }



        interactable.BaseInteract();


    }

    void Update() 
    {

        if (!canInteract) return;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 3, InteractableLayerMask))
        {
            interactable = hit.collider.GetComponent<Interactable>();
            // picked1 = interactable.gameObject;
            PlayerUI.UpdateText(interactable.PromptMessage);
            PlayerUI.UpdateDescriptionText(interactable.Descriptiontext);
            PlayerUI.Descriptionshow();

        }
        else
        {
            interactable = null;
            PlayerUI.UpdateText(string.Empty);
            PlayerUI.UpdateDescriptionText(string.Empty);
            PlayerUI.Descriptionhide();
        }
    }
}