using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : Interactable
{
    [SerializeField]
    private GameObject cabinetdoor;
    private bool cabinetdooropen;
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
        cabinetdoor.GetComponent<Animator>().SetBool("cabinetopen",cabinetdooropen);
    }
}
