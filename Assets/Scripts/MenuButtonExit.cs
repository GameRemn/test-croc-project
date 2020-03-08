using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonExit : InteractiveObject
{
    private void OnMouseDown()
    {
        Application.Quit();
    }
}
