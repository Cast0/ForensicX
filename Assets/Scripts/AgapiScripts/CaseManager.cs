using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseManager : MonoBehaviour
{
    public string caseWoundType;
    public int totalWounds;

    int currentWOundCount;
    // Start is called before the first frame update
    public static CaseManager instance;
    private void Awake()
    {
        instance = this;
    }
    public void IncrementWoundCount()
    {
        currentWOundCount++;
    }
    public int GetWoundCount()
    {
        return currentWOundCount;
    }
    void Start()
    {
        currentWOundCount = 0;

    }

    // Update is called once per frame
    void Update()
    {

    }
}

