using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadBook : MonoBehaviour
{

    [SerializeField] GameObject bookDisplay;
    public AudioSource pickUpSound;

    bool canShow = false;
    public GameObject MessagePanel;
    public bool Action = false;


    public void Start()
    {

    
        bookDisplay.SetActive(false);

    }

    public void Update()
    {
        if (!canShow) return;
        // MessagePanel.SetActive(false);
        CaseManager.instance.TriggerBookRead();
        pickUpSound.Play();

        bookDisplay.SetActive(true);

        // ItemDescription.SetActive(false);

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
