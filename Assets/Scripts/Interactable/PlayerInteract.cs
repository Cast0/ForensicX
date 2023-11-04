using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEditor.Search;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] pickanddropscripttest pickAndDrop;
    [SerializeField] Player_HandStatus player_HandStatus;
    public LayerMask InteractableLayerMask = 6;
    private PlayerUI PlayerUI;
    Interactable interactable = null;
    GameObject picked1;

    // Start is called before the first frame update
    void Start()
    {
        InputManager.instance.playerInteract += OnInteract; // used event to only detect player input in one update method. Avoid using Update method as much as possible 

        PlayerUI = GetComponent<PlayerUI>();
    }



    private void OnInteract()
    {
        if (interactable != null)
        {

            GameObject picked = interactable.gameObject;
            Debug.Log(picked.name);

            interactable.BaseInteract();

            if (picked.tag == "Pickable")
            {
                pickAndDrop.Pickup(picked);
                player_HandStatus.triggerClipboard(picked);
            }




        }
    }

    void FixedUpdate() // changed to fixd update for optimized physics
    {


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