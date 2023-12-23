using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChecklistHandler : MonoBehaviour // this class is attached to the template
{

    [SerializeField] TextMeshProUGUI title;
    [SerializeField] ChecklistToggle checklistItemTemplate;
    [SerializeField] Transform parentTrans;
    VerticalLayoutGroup verticalLayoutGroup;
    private void Start()
    {
        // only activate the game object to refresh the snap scroll
    }


    private void OnChecklistDisplayed(bool obj)
    {

        gameObject.SetActive(obj);

    }

    public void Setup(Checklist _checklist)
    {
        InteractionEvents.instance.checklistDisplayed += OnChecklistDisplayed;


        title.text = _checklist.checklistTitle;
        foreach (var item in _checklist.checklistItem)
        {

            ChecklistToggle checklistToggle = Instantiate(checklistItemTemplate, parentTrans);

            checklistToggle.gameObject.SetActive(true);
            checklistToggle.SetupItem(item);

        }

        
    }
}
