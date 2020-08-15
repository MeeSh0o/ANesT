using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

//显示细节
public class ShowDetailFrame : MonoSingleton<ShowDetailFrame>
{
    [Header("父物体，用于显示和隐藏")]
    public GameObject ParentGo;

    [Header("详情图片")]
    public Image DetailImage;

    [Header("背景取消按钮")]
    public Button CancelButton;

    [Header("物体按钮")]
    public Button ItemButton;

    private Action _onClick;

    private void Start()
    {
        CancelButton.onClick.AddListener(SetDisable);
        ItemButton.onClick.AddListener(ClickUseItem);
    }

    private void ClickUseItem()
    {
        if (_onClick != null)
        {
            _onClick();
            ParentGo.SetActive(false);
        }
    }

    private void SetDisable()
    {
        ParentGo.SetActive(false);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="name"></param>
    public void ShowImage(Sprite sprite, Action onClick)
    {
        ParentGo.SetActive(true);
        _onClick = onClick;
        DetailImage.sprite = sprite;
    }
}