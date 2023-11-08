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
    void Start()
    {
        toggle.onValueChanged.AddListener(StrikeText);
    }
    public void StrikeText(bool value)
    {
        if (value) { itemText.fontStyle = FontStyles.Strikethrough; return; }
        itemText.fontStyle = FontStyles.Normal;

    }


    // Update is called once per frame
    void Update()
    {

    }
}
