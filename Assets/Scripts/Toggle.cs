using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : InteractiveObject
{
    public bool value;
    public Sprite OnSprite;
    public Sprite OffSprite;
    private void Start()
    {
        ToggleSet();
    }
    private void OnMouseDown()
    {
        value = !value;
        ToggleSet();
        InteractiveObjectCheck();
    }
    public void ToggleSet()
    {
        if (value)
        {
            sr.sprite = OnSprite;
        }
        else
        {
            sr.sprite = OffSprite;
        }
    }
}
