using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class Player_HandStatus
{
    public static bool clipBoardIOnHand = false;


    public static void triggerClipboard(GameObject tr)
    {
        clipBoardIOnHand = tr.TryGetComponent<Clipboard>(out _);

    }
}
