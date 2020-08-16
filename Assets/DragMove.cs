using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMove : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private int count = 0;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position -
                 Camera.main.ScreenToWorldPoint(
                     new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var drop = other.gameObject.GetComponentInParent<WaterDrop>();
        Debug.Log("打飞机看的," + drop);
        if (drop)
        {
            drop.HideDrop();
            count++;
            if (count == 3)
            {
                
            }
        }
    }
}