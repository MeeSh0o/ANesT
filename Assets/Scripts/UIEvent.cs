using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public static class UIEvent
{
    static EventTrigger GetTrigger(UnityEngine.GameObject go)
    {
        EventTrigger trigger = go.GetComponent<EventTrigger>() ?? go.AddComponent<EventTrigger>();
        if (trigger.triggers == null)
        {
            trigger.triggers = new List<EventTrigger.Entry>();
        }

        return trigger;
    }


    public static EventTrigger.Entry AddEventEntry(UnityEngine.GameObject go, EventTriggerType type,
        UnityAction<BaseEventData> callback)
    {
        EventTrigger.TriggerEvent e = new EventTrigger.TriggerEvent();
        e.AddListener(callback);
        EventTrigger trigger = GetTrigger(go);
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = type;
        entry.callback = e;
        trigger.triggers.Add(entry);

        return entry;
    }

    public static void RemoveEventEntry(UnityEngine.GameObject go, EventTrigger.Entry entry)
    {
        EventTrigger trigger = GetTrigger(go);
        trigger.triggers.Remove(entry);
    }

    public static EventTrigger.Entry AddOnPointerClick(this UnityEngine.GameObject go,
        UnityAction<BaseEventData> callback)
    {
        return AddEventEntry(go, EventTriggerType.PointerClick, callback);
    }

    public static EventTrigger.Entry AddOnBeginDrag(this UnityEngine.GameObject go, UnityAction<BaseEventData> callback)
    {
        return AddEventEntry(go, EventTriggerType.BeginDrag, callback);
    }

    public static EventTrigger.Entry AddOnCancel(this UnityEngine.GameObject go, UnityAction<BaseEventData> callback)
    {
        return AddEventEntry(go, EventTriggerType.Cancel, callback);
    }

    public static EventTrigger.Entry AddOnDeselect(this UnityEngine.GameObject go, UnityAction<BaseEventData> callback)
    {
        return AddEventEntry(go, EventTriggerType.Deselect, callback);
    }

    public static EventTrigger.Entry AddOnDrag(this UnityEngine.GameObject go, UnityAction<BaseEventData> callback)
    {
        return AddEventEntry(go, EventTriggerType.Drag, callback);
    }

    public static EventTrigger.Entry AddOnDrop(this UnityEngine.GameObject go, UnityAction<BaseEventData> callback)
    {
        return AddEventEntry(go, EventTriggerType.Drop, callback);
    }

    public static EventTrigger.Entry AddOnEndDrag(this UnityEngine.GameObject go, UnityAction<BaseEventData> callback)
    {
        return AddEventEntry(go, EventTriggerType.EndDrag, callback);
    }

    public static EventTrigger.Entry AddOnInitializePotentialDrag(this UnityEngine.GameObject go,
        UnityAction<BaseEventData> callback)
    {
        return AddEventEntry(go, EventTriggerType.InitializePotentialDrag,
            callback);
    }

    public static EventTrigger.Entry AddOnMove(this UnityEngine.GameObject go, UnityAction<BaseEventData> callback)
    {
        return AddEventEntry(go, EventTriggerType.Move, callback);
    }

    public static EventTrigger.Entry AddOnPointerDown(this UnityEngine.GameObject go,
        UnityAction<BaseEventData> callback)
    {
        return AddEventEntry(go, EventTriggerType.PointerDown, callback);
    }

    public static EventTrigger.Entry AddOnPointerEnter(this UnityEngine.GameObject go,
        UnityAction<BaseEventData> callback)
    {
        return AddEventEntry(go, EventTriggerType.PointerEnter, callback);
    }

    public static EventTrigger.Entry AddOnPointerExit(this UnityEngine.GameObject go,
        UnityAction<BaseEventData> callback)
    {
        return AddEventEntry(go, EventTriggerType.PointerExit, callback);
    }

    public static EventTrigger.Entry AddOnPointerUp(this UnityEngine.GameObject go, UnityAction<BaseEventData> callback)
    {
        return AddEventEntry(go, EventTriggerType.PointerUp, callback);
    }

    public static EventTrigger.Entry AddOnScroll(this UnityEngine.GameObject go, UnityAction<BaseEventData> callback)
    {
        return AddEventEntry(go, EventTriggerType.Scroll, callback);
    }

    public static EventTrigger.Entry AddOnSubmit(this UnityEngine.GameObject go, UnityAction<BaseEventData> callback)
    {
        return AddEventEntry(go, EventTriggerType.Submit, callback);
    }

    public static EventTrigger.Entry AddOnUpdateSelected(this UnityEngine.GameObject go,
        UnityAction<BaseEventData> callback)
    {
        return AddEventEntry(go, EventTriggerType.UpdateSelected, callback);
    }
}