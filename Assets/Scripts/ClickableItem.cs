using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableItem : MonoBehaviour
{
    public string name;
    public Sprite sprite;
    public string desc;
    public TriggerType triggerType = TriggerType.PickUp;
    [Tooltip("表示可以触发多少次,负数为无限次")] public int triggerTimes = 1;

    [Tooltip("触发目标,对话/打开对象")] public string triggerTarget;

    private int currentTriggerTimes = 0;

    public Dialog girlBalloon;

    void Start()
    {
        gameObject.AddOnPointerClick(OnClick);
    }

    private void OnClick(BaseEventData arg0)
    {
        if (triggerTimes >= 0 && currentTriggerTimes >= triggerTimes)
        {
            //触发完成
            return;
        }

        currentTriggerTimes++;
        switch (triggerType)
        {
            case TriggerType.PickUp:
                //拾取
                Inventory.Instance.AddItem(this);
                break;
            case TriggerType.Dialog:
                //对话
                switch (triggerTarget)
                {
                    case "小女孩":
                        girlBalloon.ShowMessage("发放的解放军的卡死了福建大卡拉屎福建大卡生姜可乐");
                        break;
                }

                break;
            case TriggerType.Open:
                //打开啥
                break;
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