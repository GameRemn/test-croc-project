using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario : MonoBehaviour
{
    public string scenarioName;
    public List<Stage> Stages;
    public Transform textPrefab;
    [HideInInspector]
    public int enumerator = -1;

    private void Awake()
    {
        CreateWindowMassage(scenarioName, 3);
        for (int i = 0; i < Stages.Count; i++)
        {
            Stages[i].StageGrouping(this);
        }
        NextStage();
    }
    public void NextStage()
    {
        enumerator++;
        if (enumerator == Stages.Count)
        {
            enumerator = -1;
            CreateWindowMassage("Результат", 3 ,true);
        }
        else
        {
            CreateWindowMassage(Stages[enumerator].stageName, 2);
        }
    }
    public void CreateWindowMassage(string message, int layer, bool finalMessage = false)
    {
        WindowMessage wm = Instantiate(textPrefab).GetComponent<WindowMessage>();
        wm.transform.position = new Vector3(0, 0, -layer);
        wm.text.text = message;
        wm.finalMassage = finalMessage;
    }
}

