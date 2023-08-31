using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class ObjectHold : MonoBehaviour
{
    public GameObject Object;
    public Transform PlayerTransform;
    public float range = 3f;
    public float Go = 100f;
    public Camera Camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            StartPickUp();
        }
        if (Input.GetKeyUp("g"))
        {
            Drop();
        }
        void StartPickUp()
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range))
            {
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                   PickUp();
                }
            }
        }
        void PickUp ()
        {
            Object.transform.SetParent(PlayerTransform);

        }
        void Drop ()
        {
            PlayerTransform.DetachChildren();
        }
    }
}
