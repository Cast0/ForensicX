using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_HandStatus : MonoBehaviour
{
    bool clipBoardIOnHand = false;

    private void Start()
    {

    }

    public void triggerClipboard(GameObject tr)
    {
        clipBoardIOnHand = tr.TryGetComponent<Clipboard>(out _);
    }
}
