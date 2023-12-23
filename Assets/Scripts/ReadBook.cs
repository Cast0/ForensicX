using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadBook : Interactable
{

    [SerializeField] GameObject bookDisplay;
    public AudioSource pickUpSound;

    bool canShow = false;

    public bool Action = false;


    public void Start()
    {


        bookDisplay.SetActive(false);

    }

    protected override void Interact()
    {
        if (!canShow) return;

        CaseManager.instance.TriggerBookRead();
        pickUpSound.Play();

        bookDisplay.SetActive(true);


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // MessagePanel.SetActive(true);
            canShow = true;

            // ItemDescription.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // MessagePanel.SetActive(false);
            canShow = false;
            bookDisplay.SetActive(false);
        }
    }
}
