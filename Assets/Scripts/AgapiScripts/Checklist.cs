using System.Collections;
using System.Collections.Generic;
using DanielLochner.Assets.SimpleScrollSnap;
using UnityEngine;
[CreateAssetMenu(fileName = "New Checklist", menuName = "Create Checklist")]
public class Checklist : ScriptableObject
{
    public string checklistTitle;
    public List<string> checklistItem;

}
