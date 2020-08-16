using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Text nameText;
    public Image iconImage;
    public Image background;
    [NonSerialized] public Item rawItem;
    private bool _isSelected;

    public bool isSelected
    {
        get { return _isSelected; }
        set
        {
            background.color = value ? Color.red : Color.white;
            _isSelected = value;
        }
    }


    void Start()
    {
        gameObject.AddOnPointerClick(OnClick);
    }

    private void OnClick(BaseEventData arg0)
    {
        var e = arg0 as PointerEventData;
        if (e.clickCount >= 2)
        {
            //双击
            ShowDetailFrame.Instance.ShowImage(iconImage.sprite, null);
            return;
        }

        isSelected = !isSelected;
    }

    public void Set(Item item)
    {
        this.rawItem = item;
        this.nameText.text = item.name;
        this.iconImage.sprite = item.sprite;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}