using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : InteractiveObject
{
    Transform thisTransform;
    float mouseAngle;
    Vector2 mouseVector;
    float startAngle;
    public void Start()
    {
        thisTransform = transform;
        startAngle = thisTransform.eulerAngles.z;
    }
    private void OnMouseDown()
    {
        mouseVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - thisTransform.position;
        mouseAngle = Mathf.Atan2(mouseVector.y, mouseVector.x) * Mathf.Rad2Deg - thisTransform.eulerAngles.z; //Угол можеду мышкой и переключателем
    }
    private void OnMouseDrag()
    {
        mouseVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - thisTransform.position;
        float angle = Mathf.Atan2(mouseVector.y, mouseVector.x) * Mathf.Rad2Deg - mouseAngle;
        thisTransform.eulerAngles = new Vector3(0, 0, angle);
    }
    private void OnMouseUp()
    {
        if(thisTransform.eulerAngles.z != startAngle)
        {
            startAngle = thisTransform.eulerAngles.z;
            InteractiveObjectCheck();
        }
    }
}
