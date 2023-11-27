using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Laptop : Interactable
{
    [SerializeField] Material material;
    [SerializeField] GameObject laptopPanel;
    CinemachineVirtualCamera SelfVirtualCam;
    // Start is called before the first frame update
    [SerializeField] Transform perspectiveTransform;
    [SerializeField] TextMeshProUGUI woudnCountText;
    // [SerializeField] ScoreSystem scoreSystem;
    [SerializeField] TMP_Dropdown dropdown;
    Transform followHolder;
    private void Awake()
    {
        // InteractionEvents.instance.laptopInteracted += OnLaptopInteracted;
        laptopPanel.SetActive(false);
    }
    public void SubmitInspection()
    {
        Timer.instance.StopCount();
        ScoreSystem.instance.EvaulateInspection(dropdown.options[dropdown.value].text);
    }
    public void OnLaptopLeft()
    {
        InteractionEvents.instance.LaptopInteracted?.Invoke(false);
        laptopPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SelfVirtualCam.Follow = followHolder;
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

    protected override void Interact(CinemachineVirtualCamera virtualCamera)
    {
        SelfVirtualCam = virtualCamera;
        InteractionEvents.instance.LaptopInteracted?.Invoke(true);
        SetupLaptopUI();
        followHolder = SelfVirtualCam.Follow;
        laptopPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SelfVirtualCam.Follow = perspectiveTransform;


        // Disable emission by setting it to black
        material.SetColor("_EmissionColor", Color.black);

        // Disable the "_EMISSION" keyword
        material.DisableKeyword("_EMISSION");


        // playerUI.ClearUI();

    }
}
