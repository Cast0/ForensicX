using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private GameObject itemDescription;
    [SerializeField] private TextMeshProUGUI descriptionText;

    void Start()
    {
<<<<<<< Updated upstream

    }

    public void UpdateText(string PromptMessage)
    {
        PromptText.text = PromptMessage;
=======
        InteractionEvents.instance.LaptopInteracted += ClearUI;
        InteractionEvents.instance.DeadBodyInteracted += ClearUI;
        InteractionEvents.instance.exitDoor += ClearUI;

        InteractionEvents.instance.CameraChangeInteract += ClearUI;
    }

    public void ClearUI(bool value)
    {
        if (!value) return;
        ClearUIInternal();
    }

    public void ClearUI()
    {
        ClearUIInternal();
>>>>>>> Stashed changes
    }

    private void ClearUIInternal()
    {
        promptText.text = string.Empty;
        descriptionText.text = string.Empty;
        itemDescription.SetActive(false);
    }

    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }

    public void UpdateDescriptionText(string descriptionText)
    {
        this.descriptionText.text = descriptionText;
    }

    public void Descriptionshow(string description, string prompt)
    {
        promptText.text = prompt;
        descriptionText.text = description;
        itemDescription.SetActive(true);
    }

    public void Descriptionhide()
    {
        ClearUIInternal();
    }
}
