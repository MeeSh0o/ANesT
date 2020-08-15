using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickableItem : MonoBehaviour
{
    [SerializeField] public Item item;

    public Dialog girlBalloon;
    public Trigger[] triggers = new Trigger[] { };

    [SerializeField]
    [Header("如果需要特写")]
    public Sprite DetailSprite;

    private void Start()
    {
        var graphic = GetComponent<MaskableGraphic>();
        if (graphic)
        {
            gameObject.AddOnPointerClick((e) => Trigger());
        }
    }

    private void OnMouseUp()
    {
        //这里用Click防止突然闪现出现按钮被秒点
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (DetailSprite != null)
        {
            ShowDetailFrame.Instance.ShowImage(DetailSprite, Trigger);
        }
        else
        {
            Trigger();
        }
    }

    private void Trigger()
    {
        foreach (Trigger trigger in triggers)
        {
            trigger.DoTrigger(this);
        }
    }

    private void OnClick(BaseEventData arg0)
    {
        Trigger();
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