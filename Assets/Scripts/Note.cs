using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : Interactable
{
    [SerializeField]
    private RawImage _noteImage;
    public GameObject note;
    public AudioSource pickUpSound;

    public GameObject MessagePanel;
    private bool canShow = false;

    public void Start()
    {
        MessagePanel.SetActive(false);
        note.SetActive(false);

    }

    protected override void Interact()
    {
        if (!canShow) return;

        pickUpSound.Play();
        _noteImage.enabled = true;
        note.SetActive(true);


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // MessagePanel.SetActive(true);

            canShow = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
       
        canShow = false;
        note.SetActive(false);

        _noteImage.enabled = false;

    }
}
