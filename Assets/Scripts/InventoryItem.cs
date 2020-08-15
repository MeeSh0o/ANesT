using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Text nameText;
    public Image iconImage;
    [NonSerialized] public Item rawItem;

    void Start()
    {
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