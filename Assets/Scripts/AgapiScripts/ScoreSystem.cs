using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject scorePanel;
    public SceneLoader sceneLoader;
    void Start()
    {
        InteractionEvents.instance.exitDoor += DisplayScore;
        scorePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LeaveCase()
    {
        sceneLoader?.LoadScene(0);
    }

    public void DisplayScore()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        scorePanel.SetActive(true);
    }
}
