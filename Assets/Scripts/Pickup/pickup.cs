using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickanddropscripttest : MonoBehaviour
{
    [SerializeField] Transform objectOnHand;
    public GameObject camera;
    float maxpickupdistance = 3;
    GameObject itemcurrentlyholding = null;
    bool isholding = false;

    void Start()
    {
        InputManager.instance.G_Input += DropItem;
    }

    public void DropItem()
    {
        Drop(itemcurrentlyholding);
        Player_HandStatus.triggerClipboard(gameObject); // use non clipboard game object to trigger false on clipboardonhand
    }

    // public void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.E))
    //     {
    //         Pickup();
    //     }
    //     if (Input.GetKeyDown(KeyCode.G))
    //     {
    //         Drop();
    //     }
    // }

    private void Pickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, maxpickupdistance))
        {
            if (hit.transform.tag == "Pickable")
            {

                if (isholding) Drop();
                {
                    itemcurrentlyholding = hit.transform.gameObject;

                    foreach (var c in hit.transform.GetComponentsInChildren<Collider>()) if (c != null) c.enabled = false;
                    foreach (var r in hit.transform.GetComponentsInChildren<Rigidbody>()) if (r != null) r.isKinematic = true;

                    itemcurrentlyholding.transform.parent = transform;
                    itemcurrentlyholding.transform.localPosition = Vector3.zero;
                    itemcurrentlyholding.transform.localEulerAngles = Vector3.zero;

                    isholding = true;
                }
            }
        }
    }

    private void Drop()
    {
        itemcurrentlyholding.transform.parent = null;
        foreach (var c in itemcurrentlyholding.GetComponentsInChildren<Collider>()) if (c != null) c.enabled = true;
        foreach (var r in itemcurrentlyholding.GetComponentsInChildren<Rigidbody>()) if (r != null) r.isKinematic = false;
        isholding = false;

        itemcurrentlyholding.transform.eulerAngles = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        itemcurrentlyholding = null;

    }


    public void Pickup(GameObject pickedUp) // assuming that this class is attached tot he gameobject of where the item is to be placed
    {


        pickedUp.TryGetComponent<Collider>(out Collider component);
        component.enabled = false;

        try
        {
            pickedUp.TryGetComponent<Rigidbody>(out Rigidbody rigidbody);
            rigidbody.isKinematic = true;
        }
        catch
        {
            Debug.LogWarning("Kinematics error");
        }



        if (isholding) Drop(itemcurrentlyholding);

        itemcurrentlyholding = pickedUp.gameObject;
        pickedUp.transform.parent = objectOnHand;
        pickedUp.transform.localPosition = Vector3.zero;
        pickedUp.transform.localRotation = Quaternion.identity;

        isholding = true;



    }
    private void Drop(GameObject dropping)
    {
        if (dropping != null)
        {
            dropping.TryGetComponent<Collider>(out Collider component);
            component.enabled = true;
            dropping.transform.parent = null;
            try
            {
                dropping.TryGetComponent<Rigidbody>(out Rigidbody rigidbody);
                rigidbody.isKinematic = false;
            }
            catch
            {
                Debug.LogWarning("Kinematics error");
            }
        }


        isholding = false;
        itemcurrentlyholding = null;



    }

}