using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Act
{
    public string actDescription;
    public InteractiveObject interactiveObject;
    [System.NonSerialized] public Stage myStage;
    public void ActGrouping(Stage stage)
    {
        myStage = stage;
        interactiveObject.interactiveObjectGrouping(this);
    }
    public bool ActCheck()
    {
        int enumerator = myStage.enumerator;
        if (enumerator != -1 && myStage.Acts[enumerator] == this)
        {
            myStage.NextAct();
            return true;
        }
        else
            return false;
    }
}
