using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Checklist Item", menuName = "Add Checklist Item")]

public class ChecklistItem : ScriptableObject
{
    public string itemName;
 [TextArea(10,10)]
    public string itemDescription;
}
