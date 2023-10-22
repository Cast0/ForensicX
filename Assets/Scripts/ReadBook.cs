using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadBook : MonoBehaviour
{
    [SerializeField]
    private RawImage _bookImage;
    public GameObject left;
    public GameObject right;
    public AudioSource pickUpSound;

    public GameObject MessagePanel;
    public bool Action = false;


    public void Start()
    {
        MessagePanel.SetActive(false);
        left.SetActive(false);
        right.SetActive(false);

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
                _bookImage.enabled = true;
                left.SetActive(true);
                right.SetActive(true);
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
            left.SetActive(false);
            right.SetActive(false);

            _bookImage.enabled = false;
        }
    }
}
