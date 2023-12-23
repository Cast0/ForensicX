using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wound : MonoBehaviour
{
    [SerializeField] bool canIncrement;
    [SerializeField] GameObject particleSystem;
    private void Start()
    {
        particleSystem.SetActive(false);
    }
    public void TryIncrementWound()
    {
        if (canIncrement)
        {
            CaseManager.instance.IncrementWoundCount();
            particleSystem.SetActive(true);
            canIncrement = false;
        }
    }
}
