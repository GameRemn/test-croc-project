using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario : MonoBehaviour
{
    public string scenarioName;
    public List<Stage> Stages;
    public Transform textPrefab;
    [HideInInspector]
    public int enumerator;

    private void Awake()
    {
        CreateWindowMessage(scenarioName, 3);
        enumerator = -1;
        int stagesCount = Stages.Count;
        for (int i = 0; i < stagesCount; i++)
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
            CreateWindowMessage("Поздравляем, \nсценарий заврешён,\nколичество ошибок: " + InteractiveObject.errorCount + "!", 3 ,true);
        }
        else
        {
            CreateWindowMessage(Stages[enumerator].stageName, 2);
            Stages[enumerator].NextAct();
        }
    }
    public void CreateWindowMessage(string message, int layer, bool finalMessage = false)
    {
        WindowMessage wm = Instantiate(textPrefab).GetComponent<WindowMessage>();
        wm.transform.position = new Vector3(0, 0, -layer);
        wm.text.text = message;
        wm.finalMessage = finalMessage;
    }
}

