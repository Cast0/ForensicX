using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CaseData
{
    public static int TotalRequiredWounds { get; private set; }
    public static bool isRightProcedure { get; private set; }
    public static string woundType { get; private set; }
    public static void Setup(
        int _TotalRequiredWounds,
        bool _isRightProcedure,
        string _woundType
    )
    {
        TotalRequiredWounds = _TotalRequiredWounds;
        isRightProcedure = _isRightProcedure;
        woundType = _woundType;

    }
}

