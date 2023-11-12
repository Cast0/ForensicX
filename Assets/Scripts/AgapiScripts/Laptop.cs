using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;

public class Laptop : Interactable
{
    [SerializeField] Material material;
    [SerializeField] GameObject laptopPanel;
    [SerializeField] CinemachineVirtualCamera virtualCameral;
    // Start is called before the first frame update
    [SerializeField] Transform perspectiveTransform;
    [SerializeField] TextMeshProUGUI woudnCountText;
    Transform followHolder;
    private void Awake()
    {
        // InteractionEvents.instance.laptopInteracted += OnLaptopInteracted;
        laptopPanel.SetActive(false);
    }

    public void OnLaptopLeft()
    {
        InteractionEvents.instance.LaptopInteracted?.Invoke(false);
        laptopPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        virtualCameral.Follow = followHolder;
        material.SetColor("_EmissionColor", Color.white);
        material.EnableKeyword("_EMISSION");
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void SetupLaptopUI()
    {
        woudnCountText.text = string.Format("Wound Inspected: {0}/{1}", CaseManager.instance.GetWoundCount(), CaseManager.instance.totalWounds);
    }

    protected override void Interact()
    {
        InteractionEvents.instance.LaptopInteracted?.Invoke(true);
        SetupLaptopUI();
        followHolder = virtualCameral.Follow;
        laptopPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        virtualCameral.Follow = perspectiveTransform;


        // Disable emission by setting it to black
        material.SetColor("_EmissionColor", Color.black);

        // Disable the "_EMISSION" keyword
        material.DisableKeyword("_EMISSION");


        // playerUI.ClearUI();

    }
}
