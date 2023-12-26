using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warning : MonoBehaviour
{
    public void LoadSceneWithDelay()
    {
        // Invoke the LoadScene method after a 2-minute (120 seconds) delay
        Invoke("LoadScene", 120f);
    }

    private void LoadScene()
    {
        // Load the "Main Menu" scene
        SceneManager.LoadScene("Main Menu");
    }
}
