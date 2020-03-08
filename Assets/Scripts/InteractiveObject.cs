using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour // если ты слышал про solid, то должен был сделать интерфейс The Liskov Substitution Principle
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
    public void InteractiveObjectCheck() // не совсем понятно что именно проверяет этот метод - либо придумай название получше, либо напиши коммент, но лушче название
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
                myActs[0].myStage.myScenario.CreateWindowMassage("Критическая ошибка!\n" + name + " была использована в неправильном порядке!", 4, true);
            }
        }
        else
        {
            errorCount++;
        }
    }
}
