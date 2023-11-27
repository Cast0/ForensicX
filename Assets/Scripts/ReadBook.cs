using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadBook : Interactable
{
    [SerializeField]
    private RawImage _bookImage;
    public GameObject left;
    public GameObject right;
    public AudioSource pickUpSound;
    public GameObject _BGImage;
    public GameObject ItemDescription;

    public GameObject MessagePanel;
    public bool canShow = false;


    public void Start()
    {
        MessagePanel.SetActive(false);
        left.SetActive(false);
        right.SetActive(false);
        _BGImage.SetActive(false);
        ItemDescription.SetActive(false);

    }

    protected override void Interact()
    {
        if (!canShow) return;
        // MessagePanel.SetActive(false);

        pickUpSound.Play();
        _bookImage.enabled = true;
        left.SetActive(true);
        right.SetActive(true);
        _BGImage.SetActive(false);
        // ItemDescription.SetActive(false);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // MessagePanel.SetActive(true);
            canShow = true;
            _BGImage.SetActive(true);
            // ItemDescription.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // MessagePanel.SetActive(false);
            canShow = false;
            left.SetActive(false);
            right.SetActive(false);
            _BGImage.SetActive(false);
            // ItemDescription.SetActive(false);

            _bookImage.enabled = false;
        }
    }
}
