using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ChecklistToggle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI itemText;
    [SerializeField] Toggle toggle;
    ChecklistItem checklistItem = null;
    void Start()
    {
        toggle.onValueChanged.AddListener(StrikeText);
    }
    public void SetupItem(ChecklistItem _checklistItem){
        checklistItem = _checklistItem;
        itemText.text = checklistItem.itemName.ToUpper() +" "+ checklistItem.itemDescription;
    }
    public void StrikeText(bool value)
    {
        if (value)
        {
            itemText.fontStyle = FontStyles.Strikethrough;
            ChecklistItemRecord.strikedItems.Add(checklistItem);
            Debug.Log("New Items in Striked List: ");
            foreach (var item in ChecklistItemRecord.strikedItems)
            {
                Debug.Log(item);
            }
            return;
        }
        itemText.fontStyle = FontStyles.Normal;



    }


    // Update is called once per frame
    void Update()
    {

    }
}
