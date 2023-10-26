using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickanddropscripttest : MonoBehaviour
{

    public GameObject camera;
    float maxpickupdistance = 3;
    GameObject itemcurrentlyholding;
    bool isholding = false;



    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Pickup();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Drop();
        }
    }

    public void Pickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, maxpickupdistance))
        {
            if (hit.transform.tag == "Pickable")
            {

                if (isholding) Drop();

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

    public void Drop()
    {
        itemcurrentlyholding.transform.parent = null;
        foreach (var c in itemcurrentlyholding.GetComponentsInChildren<Collider>()) if (c != null) c.enabled = true;
        foreach (var r in itemcurrentlyholding.GetComponentsInChildren<Rigidbody>()) if (r != null) r.isKinematic = false;
        isholding = false;

        itemcurrentlyholding.transform.eulerAngles = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        itemcurrentlyholding = null;

    }


}