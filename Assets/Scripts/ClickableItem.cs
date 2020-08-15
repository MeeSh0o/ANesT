using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableItem : MonoBehaviour
{
    public string name;
    public Sprite sprite;
    public string desc;
    public bool isTriggered = false;
    [Tooltip("是否可拾取")] public bool canPickup = true;

    void Start()
    {
        gameObject.AddOnPointerClick(OnClick);
    }

    private void OnClick(BaseEventData arg0)
    {
        if (!isTriggered)
        {
            isTriggered = true;
            if (canPickup)
            {
                Inventory.Instance.AddItem(this);
            }
        }
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