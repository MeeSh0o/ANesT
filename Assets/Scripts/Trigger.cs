using System;
using System.Collections.Generic;
using System.Linq;
using ByteSheep.Events;
using UnityEngine;

[Serializable]
public class Trigger
{
    public TriggerType triggerType = TriggerType.None;
    [NonSerialized] public int currentTriggerTimes = 0;
    [Header("表示可以触发多少次,负数为无限次")] public int triggerTimes = -1;
    [Header("触发目标,对话/打开对象")] public string triggerTarget;
    [Header("游戏中的flag,收集完成即可过关")] public string flag;
    [Header("需要对应的flag")] public string[] NeedFlags = new string[] { };
    [Header("不能有的Flag")] public string[] WithOutFlags = new string[] { };

    [Header("监听操作，当都返回ture则继续往下走")]
    public List<TriggerListener> TriggerListeners;

    [SerializeField]
    [Header("当触发成功")]
    public QuickEvent OnSuccessTrigger;

    public void DoTrigger(ClickableItem item)
    {
        if (triggerTimes >= 0 && currentTriggerTimes >= triggerTimes)
        {
            //触发完成
            return;
        }

        if (!NeedFlags.All(f => Stage.Instance.HasFlag(f)))
        {
            Debug.Log("缺少前置条件");
            return;
        }

        if (WithOutFlags.Any(f => Stage.Instance.HasFlag(f)))
        {
            Debug.Log("含有不能有的flag");
            return;
        }

        currentTriggerTimes++;
        //这里把监听器作为一个额外的判断条件或者功能
        foreach (var listener in TriggerListeners)
        {
            if (listener != null && !listener.OnTrigger(this))
            {
                return;
            }
        }

        DoTriggerEffect(item);
    }

    public void DoTriggerEffect(ClickableItem item)
    {
        switch (triggerType)
        {
            case TriggerType.PickUp:
                //拾取
                Inventory.Instance.AddItem(item);
                break;

            case TriggerType.Dialog:
                //对话
                switch (triggerTarget)
                {
                    case "对话.一幅彩色的画":
                        item.girlBalloon?.ShowMessage("一幅彩色的画");
                        break;
                }

                if (!string.IsNullOrEmpty(flag))
                {
                    Stage.Instance.AddFlag(flag);
                }

                break;

            case TriggerType.Open:
                //打开游戏
                CloseUpView.Instance.OpenMiniGame(triggerTarget);

                break;

            case TriggerType.None:

                if (!string.IsNullOrEmpty(flag))
                {
                    Stage.Instance.AddFlag(flag);
                }

                break;
        }
        OnSuccessTrigger?.Invoke();
    }
}