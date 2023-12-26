using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CaseReset : MonoBehaviour
{
    public static Action CaseResetted;
    public void ResetCases()
    {
        PlayerPrefs.SetInt("caseUnlocked",1);
        CaseResetted?.Invoke();
    }
}
