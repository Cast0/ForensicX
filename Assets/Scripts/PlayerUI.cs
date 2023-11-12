using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI PromptText;
    [SerializeField]
    private GameObject ItemDescription;
    [SerializeField]
    private TextMeshProUGUI Descriptiontext;


    // Start is called before the first frame update
    void Start()
    {
        InteractionEvents.instance.LaptopInteracted += ClearUI;
        InteractionEvents.instance.DeadBodyInteracted += ClearUI;
    }
    public void ClearUI(bool value)
    {
        if (!value) return;

        PromptText.text = string.Empty;
        Descriptiontext.text = string.Empty;
        ItemDescription.SetActive(false);
    }
    public void ClearUI()
    {
        PromptText.text = string.Empty;
        Descriptiontext.text = string.Empty;
        ItemDescription.SetActive(false);
    }
    public void UpdateText(string PromptMessage)
    {
        PromptText.text = PromptMessage;
    }

    public void UpdateDescriptionText(string DescriptionText)
    {
        Descriptiontext.text = DescriptionText;
    }

    public void Descriptionshow()
    {
        ItemDescription.SetActive(true);
    }

    public void Descriptionhide()
    {
        ItemDescription.SetActive(false);
    }

}