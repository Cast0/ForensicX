using System;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Laptop : Interactable
{
    [SerializeField] Material material;
    [SerializeField] GameObject laptopPanel;
    [SerializeField] Transform perspectiveTransform;
    [SerializeField] TextMeshProUGUI woudnCountText;
    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] GameObject templatePanel;
    private CinemachineVirtualCamera selfVirtualCam;
    private Transform followHolder;
    private List<ChecklistItem> selectedItems = new List<ChecklistItem>();




    private void InitializeDropdown()
    {
        List<string> checklistNames = new List<string>();

        foreach (var item in CaseManager.instance.totalCaseItems)
        {
            checklistNames.Add(item.itemName);
        }

        dropdown.AddOptions(checklistNames);
        dropdown.onValueChanged.AddListener(AddItemValueChange);
    }

    public void AddItemValueChange(int totalIndex)
    {
        // Clear the selected items list before adding new ones
        selectedItems.Clear();

        // Convert the totalIndex to an array of indices
        int[] indices = ConvertToIndices(totalIndex);

        // Loop through the selected indices and add the corresponding items to the list
        foreach (int index in indices)
        {
            ChecklistItem selectedItem = CaseManager.instance.totalCaseItems[index];

            // Check if the item is not already in the list
            if (!selectedItems.Contains(selectedItem))
            {
                // Add the selected item to the list
                selectedItems.Add(selectedItem);
            }
        }
    }

    // Helper method to convert the totalIndex to an array of indices
    private int[] ConvertToIndices(int totalIndex)
    {
        List<int> indices = new List<int>();

        for (int i = 0; i < dropdown.options.Count; i++)
        {
            if ((totalIndex & (1 << i)) != 0)
            {
                indices.Add(i);
            }
        }

        return indices.ToArray();
    }

    public void SubmitInspection()
    {
        Timer.instance.StopCount();
        CaseData.submitted = true;


        InteractionEvents.instance.ReportSubmitted?.Invoke(selectedItems);

    }

    public void OnLaptopLeft()
    {
        InteractionEvents.instance.LaptopInteracted?.Invoke(false);
        laptopPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        selfVirtualCam.Follow = followHolder;
        material.SetColor("_EmissionColor", Color.white);
        material.EnableKeyword("_EMISSION");
    }

    void Start()
    {
        InitializeDropdown();
        material.SetColor("_EmissionColor", Color.white);
        material.EnableKeyword("_EMISSION");
        laptopPanel.SetActive(false);
    }

    void SetupLaptopUI()
    {
        templatePanel.SetActive(false);
        woudnCountText.text = string.Format("Wound Inspected: {0}/{1}", CaseManager.instance.GetWoundCount(), CaseManager.instance.totalWounds);
    }

    protected override void Interact(CinemachineVirtualCamera virtualCamera)
    {
        selfVirtualCam = virtualCamera;
        InteractionEvents.instance.LaptopInteracted?.Invoke(true);
        SetupLaptopUI();
        followHolder = selfVirtualCam.Follow;
        laptopPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        selfVirtualCam.Follow = perspectiveTransform;

        material.SetColor("_EmissionColor", Color.black);
        material.DisableKeyword("_EMISSION");
    }

    // Additional methods or overrides can be added here

    // Update is called once per frame
    void Update()
    {
        // Add any necessary update logic
    }
}
