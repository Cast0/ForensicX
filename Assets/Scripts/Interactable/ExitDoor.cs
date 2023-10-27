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

    protected override void Interact()
    {
        dooropen = !dooropen;
        StartCoroutine(Loadlevel());

    }

    IEnumerator Loadlevel()
    {
        door.GetComponent<Animator>().SetTrigger("exit");
        yield return new WaitForSeconds(1);
        // type the name of the scene that you want to load
        SceneManager.LoadScene("Main Menu");
        door.GetComponent<Animator>().SetTrigger("enter");

    }
}
