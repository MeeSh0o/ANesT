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

    void Start()
    {
        var graphic = GetComponent<MaskableGraphic>();
        if (graphic)
        {
            gameObject.AddOnPointerClick((e) => Trigger());
        }
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        Trigger();
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