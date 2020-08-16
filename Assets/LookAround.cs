using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookAround : MonoBehaviour
{
    public Button left;
    public Button right;
    private string[] images = new string[]
    {
        "cj2",
        "cj4",
        "cj1",
        "cj3",
    };

    private void Start()
    {
        // left.onClick.AddListener(() =>
        //     ShowDetailFrame.Instance.ShowImage(Resources.Load<Sprite>("Sprites/Changjing/"), null));
        // right.onClick.AddListener(() =>
        //     ShowDetailFrame.Instance.ShowImage(Resources.Load<Sprite>("Sprites/Changjing/"), null));
    }
}