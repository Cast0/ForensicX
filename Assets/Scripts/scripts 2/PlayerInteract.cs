using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEditor.Search;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public LayerMask InteractableLayerMask = 6;
    private PlayerUI PlayerUI;

    // Start is called before the first frame update
    void Start()
    {
        PlayerUI = GetComponent<PlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerUI.UpdateText(string.Empty);
        PlayerUI.UpdateDescriptionText(string.Empty);
        PlayerUI.Descriptionhide();
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, InteractableLayerMask))
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
        }
    }
}