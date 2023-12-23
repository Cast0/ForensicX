using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : Interactable
{


   
    private bool dooropen;
    // Start is called before the first frame update

    protected override void Interact()
    {
        // dooropen = !dooropen;
        InteractionEvents.instance.exitDoor?.Invoke();
        // StartCoroutine(Loadlevel());

    }

   
}
