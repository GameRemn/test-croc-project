using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stage
{
    public string stageName;
    public List<Act> Acts;
    [System.NonSerialized] public Scenario myScenario;
    [HideInInspector]
    public int enumerator;
    public void StageGrouping(Scenario scenario)
    {
        myScenario = scenario;
        enumerator = -1;
        int actsCount = Acts.Count;
        for(int i = 0; i < actsCount; i++)
        {
            Acts[i].ActGrouping(this);
        }
    }
    public void NextAct()
    {
        enumerator++;
        if(enumerator == Acts.Count)
        {
            enumerator = -1;
            myScenario.NextStage();
        }
        else
        {
            myScenario.CreateWindowMessage(Acts[enumerator].actDescription + " " + Acts[enumerator].interactiveObject.name, 1);
        }
    }
}
