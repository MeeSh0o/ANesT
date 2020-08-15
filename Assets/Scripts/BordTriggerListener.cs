using System.Linq;
using UnityEngine;

public class BordTriggerListener : TriggerListener
{
    public PaintingPicture paint;

    public string[] needItems = new string[]
    {
        "画笔",
        "调色盘"
    };

    public override bool OnTrigger(Trigger trigger)
    {
        base.OnTrigger(trigger);
        var items = Inventory.Instance.GetSelectedItems();
        foreach (string n in needItems)
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
            }
        }

        if (paint.NextPicture())
        {
            Stage.Instance.AddFlag("完成上色");
        }

        return true;
    }
}