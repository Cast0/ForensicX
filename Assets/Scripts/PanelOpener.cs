using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel2;

    public void OpenPanel1()
    {
        if (Panel1 != null)
        {
            Panel1.SetActive(true);
            if (Panel2 != null)
            {
                Panel2.SetActive(false);
            }
        }
    }

    public void OpenPanel2()
    {
        if (Panel2 != null)
        {
            Panel2.SetActive(true);
            if (Panel1 != null)
            {
                Panel1.SetActive(false);
            }
        }
    }
}
