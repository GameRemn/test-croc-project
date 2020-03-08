using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowMessage : MonoBehaviour
{
    public bool finalMassage;
    public TextMesh text;
    private void Awake()
    {
        text = GetComponentInChildren<TextMesh>();
    }
    private void OnMouseDown()
    {
        if (finalMassage)
            SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
