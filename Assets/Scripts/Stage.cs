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
    public int enumerator = -1;
    public void StageGrouping(Scenario scenario)
    {
        myScenario = scenario;
        for(int i = 0; i < Acts.Count; i++)
        {
            Acts[i].ActGrouping(this);
        }
        NextAct();
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
            myScenario.CreateWindowMassage(Acts[enumerator].actDescription + " " + Acts[enumerator].interactiveObject.name, 1);
        }
    }
}
