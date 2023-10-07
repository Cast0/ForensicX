using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKeyOpenDoor : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject Instructions;
    public GameObject AnimeObject;
    public GameObject ThisTrigger;
    public AudioSource DoorOpenSound;
    public bool Action = false;

    void Start()
    {
        Instruction.SetActive(false);
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            Instruction.SetActive(true);
            Action = true;
        }
    }
    void OnTriggerExit(Collider collision)
    {
        Instruction.SetActive(false);
        Action = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instruction.SetActive(false);
            if (Action == true)
            {
                Instruction.SetActive(false);
                AnimeObject.GetComponent<Animator>().Play("DoorOpen");
                AnimeObject.GetComponent<Animator>().Play("DoorOpen2");
                ThisTrigger.SetActive(false);
                Action = false;
            }
        }
    }
}