using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    [SerializeField]
    private RawImage _noteImage;
    public GameObject note;
    public AudioSource pickUpSound;

    public GameObject MessagePanel;
    public bool Action = false;
   

    public void Start()
    {
        MessagePanel.SetActive(false);
        note.SetActive(false);  
        
    }

    public void Update()
    {
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
        if (other.gameObject.CompareTag("Player")) 
        {
            MessagePanel.SetActive(false);
            Action = false;
            note.SetActive(false);

            _noteImage.enabled = false;
        }
    }
}
