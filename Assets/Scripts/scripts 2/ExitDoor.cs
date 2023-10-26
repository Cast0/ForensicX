using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class ExitDoor : Interactable
{
    [SerializeField]
    private GameObject door;
    private bool cabinetdooropen;
    [SerializeField]
    private string sceneName;
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
        cabinetdooropen = !cabinetdooropen;
        door.GetComponent<Animator>().SetBool("doorisopen", cabinetdooropen);
        SceneManager.LoadScene(sceneName);
        
    }

}
