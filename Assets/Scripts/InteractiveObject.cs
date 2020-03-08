using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    protected SpriteRenderer sr;
    protected List<Act> myActs = new List<Act>();
    public static int errorCount = 0;
    public void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public void OnMouseEnter()
    {
        sr.color = Color.yellow;
    }
    public void OnMouseExit()
    {
        sr.color = Color.white;
    }
    public void interactiveObjectGrouping(Act act)
    {
        myActs.Add(act);
    }
    public void InteractiveObjectCheck()
    {
        if (myActs.Count > 0)
        {
            bool result = false;
            for (int i = myActs.Count - 1; i >= 0; i--) //Начинаем с конца, чтобы не активировать несколько идущих подряд действий с этим интерактивным объектом
            {
                if (myActs[i].ActCheck())
                    result = true;
            }
            if (!result)
            {
                myActs[0].myStage.myScenario.CreateWindowMessage("Критическая ошибка!\n" + name + " была \nиспользована в \nнеправильном порядке!", 4, true);
            }
        }
        else
        {
            errorCount++;
        }
    }
}
