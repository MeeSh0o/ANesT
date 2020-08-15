using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItemListener : TriggerListener
{
    [Header("使用物品条件")]
    public string[] NeedUseItems = new string[]
    {
    };

    public override bool OnTrigger(Trigger trigger)
    {
        base.OnTrigger(trigger);
        var items = Inventory.Instance.GetSelectedItems();
        foreach (string n in NeedUseItems)
        {
            bool find = false;
            foreach (var item in items)
            {
                if (item.name == n)
                {
                    find = true;
                    break;
                }
            }

            if (!find)
            {
                Debug.Log("缺少选择道具:" + name);
                //没有收集齐就不执行
                return false;
            }
        }

        return true;
    }
}