using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RotateHead : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    [SerializeField] UnityEvent rotateEvent;
    bool heldDown = false;
    // [Range(0, 1)]
    // [SerializeField] int leftRight;
    private void Update() { if (heldDown) rotateEvent?.Invoke(); }

    public void OnPointerDown(PointerEventData eventData)
    {
        heldDown = true;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        heldDown = false;
    }
}
