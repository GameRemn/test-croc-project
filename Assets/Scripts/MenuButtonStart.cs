using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonStart : InteractiveObject
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene(1);
    }
}
