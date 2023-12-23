using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadBook : MonoBehaviour
{

    [SerializeField] GameObject bookDisplay;
    public AudioSource pickUpSound;


    public GameObject MessagePanel;
    public bool Action = false;


    public void Start()
    {

    
        bookDisplay.SetActive(false);

    }

    public void Update()
    {
<<<<<<< Updated upstream
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Action == true)
            {
                MessagePanel.SetActive(false);
                Action = false;
                pickUpSound.Play();
                _bookImage.enabled = true;
                left.SetActive(true);
                right.SetActive(true);
                _BGImage.SetActive(false);
                ItemDescription.SetActive(false);
            }
        }
=======
        if (!canShow) return;
        // MessagePanel.SetActive(false);
        CaseManager.instance.TriggerBookRead();
        pickUpSound.Play();

        bookDisplay.SetActive(true);

        // ItemDescription.SetActive(false);

>>>>>>> Stashed changes
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
<<<<<<< Updated upstream
            MessagePanel.SetActive(true);
            Action = true;
            _BGImage.SetActive(true);
            ItemDescription.SetActive(true);
=======
            // MessagePanel.SetActive(true);
            canShow = true;

            // ItemDescription.SetActive(true);
>>>>>>> Stashed changes

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
<<<<<<< Updated upstream
            MessagePanel.SetActive(false);
            Action = false;
            left.SetActive(false);
            right.SetActive(false);
            _BGImage.SetActive(false);
            ItemDescription.SetActive(false);

            _bookImage.enabled = false;
=======
            // MessagePanel.SetActive(false);
            canShow = false;
            bookDisplay.SetActive(false);
>>>>>>> Stashed changes
        }
    }
}
