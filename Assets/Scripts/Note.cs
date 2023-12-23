using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{

    public GameObject noteDisplay;
    public AudioSource pickUpSound;

    private bool canShow = false;

    public void Start()
    {

        noteDisplay.SetActive(false);

    }

    public void Update()
    {
        if (!canShow) return;
        CaseManager.instance.TriggerNoteRead();
        pickUpSound.Play();
        noteDisplay.SetActive(true);


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canShow = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        canShow = false;
        noteDisplay.SetActive(false);
    }
}
