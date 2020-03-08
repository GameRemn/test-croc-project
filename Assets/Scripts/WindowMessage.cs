using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowMessage : MonoBehaviour
{
    public bool finalMessage;
    public TextMesh text;
    private void Awake()
    {
        text = GetComponentInChildren<TextMesh>();
    }
    private void OnMouseDown()
    {
        if (finalMessage)
            SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
