using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void LoadSceneWithDelay()
    {
        // Invoke the LoadScene method after a 3-second delay
        Invoke("LoadScene", 12000f);
    }

    private void LoadScene()
    {
        
        SceneManager.LoadScene("Main Menu");
    }
}
