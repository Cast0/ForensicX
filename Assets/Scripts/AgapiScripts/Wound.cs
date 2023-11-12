using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wound : MonoBehaviour
{
    [SerializeField] bool canIncrement;
    public void TryIncrementWound()
    {
        if (canIncrement)
        {
            CaseManager.instance.IncrementWoundCount();
            canIncrement = false;
        }
    }
}
