using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pregame : MonoBehaviour
{
    [SerializeField] GameObject selectionPanel;
    [SerializeField] GameObject instructionPanel;
    [SerializeField] SceneLoader sceneLoader;
    private void Start()
    {
        instructionPanel.SetActive(false);
        selectionPanel.SetActive(true);
    }
    int caseSceneSelected = 0;
    public void SelectCase(int caseNumber)
    {
        caseSceneSelected = caseNumber;
        instructionPanel.SetActive(true);
        selectionPanel.SetActive(false);
    }
    public void DoneReading()
    {
        sceneLoader.LoadScene(caseSceneSelected);


    }
}
