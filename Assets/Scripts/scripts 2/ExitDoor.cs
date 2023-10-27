using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : Interactable
{
    [SerializeField]
    private GameObject door;
    private bool dooropen;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Interact()
    {
        dooropen = !dooropen;
        //door.GetComponent<Animator>().SetBool("exitdooropen", dooropen);
        StartCoroutine(Loadlevel());

    }

    IEnumerator Loadlevel()
    {
        door.GetComponent<Animator>().SetTrigger("exit");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Main Menu");
        door.GetComponent<Animator>().SetTrigger("enter");

    }
}
