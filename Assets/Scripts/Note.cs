using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{

    public GameObject noteDisplay;
    public AudioSource pickUpSound;

<<<<<<< Updated upstream
    public GameObject MessagePanel;
    public bool Action = false;
   

    public void Start()
    {
        MessagePanel.SetActive(false);
        note.SetActive(false);  
        
=======
    private bool canShow = false;

    public void Start()
    {

        noteDisplay.SetActive(false);

>>>>>>> Stashed changes
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
                _noteImage.enabled = true;
                note.SetActive(true);
            }
        }
=======
        if (!canShow) return;
        CaseManager.instance.TriggerNoteRead();
        pickUpSound.Play();
        noteDisplay.SetActive(true);


>>>>>>> Stashed changes
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            MessagePanel.SetActive(true);
            Action = true;
            
        }
    }

    void OnTriggerExit(Collider other)
    {
<<<<<<< Updated upstream
        if (other.gameObject.CompareTag("Player")) 
        {
            MessagePanel.SetActive(false);
            Action = false;
            note.SetActive(false);

            _noteImage.enabled = false;
        }
=======
        if (!other.gameObject.CompareTag("Player")) return;

        canShow = false;
        noteDisplay.SetActive(false);
>>>>>>> Stashed changes
    }
}
