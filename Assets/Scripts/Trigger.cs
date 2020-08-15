using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class Trigger
{
    public TriggerType triggerType = TriggerType.None;
    [NonSerialized] public int currentTriggerTimes = 0;
    [Tooltip("表示可以触发多少次,负数为无限次")] public int triggerTimes = 1;
    [Tooltip("触发目标,对话/打开对象")] public string triggerTarget;
    [Tooltip("游戏中的flag,收集完成即可过关")] public string flag;
    [Tooltip("需要对应的flag")] public string[] NeedFlags = new string[] { };
    [Tooltip("不能有的Flag")] public string[] WithOutFlags = new string[] { };

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
                        item.girlBalloon.ShowMessage("一幅彩色的画");
                        break;
                }

                if (!string.IsNullOrEmpty(flag))
                {
                    Stage.Instance.AddFlag(flag);
                }

                break;
            case TriggerType.Open:
                //打开啥
                switch (triggerTarget)
                {
                    case "触发.抽屉小游戏":
                        CloseUpView.Instance.OpenMiniGame(CloseUpView.MINI_GAME_DRAWER);
                        break;
                }

                break;
            case TriggerType.None:
                
                if (!string.IsNullOrEmpty(flag))
                {
                    Stage.Instance.AddFlag(flag);
                }

                break;
        }
    }
}