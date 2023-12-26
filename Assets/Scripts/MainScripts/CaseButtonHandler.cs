using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaseButtonHandler : MonoBehaviour
{
    [SerializeField] GameObject lockOverlay;
    [SerializeField] Button button;
    [SerializeField] int casenumber = 1;
    private void Start()
    {

        CaseReset.CaseResetted += HandleCaseButton;
        HandleCaseButton();

    }
    private void OnDestroy()
    {
        CaseReset.CaseResetted -= HandleCaseButton;
    }
    private void HandleCaseButton()
    {
        if (PlayerPrefs.GetInt("caseUnlocked", 1) >= casenumber)
        {
            //unlock this button
            button.enabled = true;
            lockOverlay.SetActive(false);
        }
        else
        {
            button.enabled = false;
            lockOverlay.SetActive(true);
        }
        button.onClick.AddListener(() =>
        {
            CaseData.currentCaseOpened = casenumber;
        });
    }
}
