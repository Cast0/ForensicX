using System;
using UnityEngine;

public class WoundSelect : MonoBehaviour
{
    private Camera mainCamera;
    bool openSelection = false;

    private void Start()
    {

        mainCamera = Camera.main;
        InteractionEvents.instance.DeadBodyInteracted += OnInteracted;
    }

    private void OnInteracted(bool obj)
    {
        openSelection = obj;
    }

    private void Update()
    {
        if (!openSelection) return;
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the mouse position
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            // Check if the ray hits something
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the hit object has a Wound script
                Debug.Log("Selecting Wound "+hit.collider.name);

                if (hit.collider.TryGetComponent<Wound>(out Wound wound))
                {
                    Debug.Log("Wound selected");
                    wound.TryIncrementWound();
                    // clickToDeleteScript.OnClick();
                }
            }
        }
    }
}
