using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    [Header("游戏名称")]
    public string GameName;

    [Header("当游戏成功完成Tag")]
    public List<string> SuccessTags;

    [Header("成功时的道具")]
    public List<Item> SuccessItems;

    private bool _success = false;

    public virtual MiniGame Init(CloseUpView view)
    {
        return this;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// 当游戏成功时
    /// </summary>
    protected void OnSuccessGame()
    {
        if (!_success)
        {
            //防止重复添加
            _success = true;
            for (int i = 0; i < SuccessTags.Count; i++)
            {
                Stage.Instance.AddFlag(SuccessTags[i]);
            }
            for (int i = 0; i < SuccessItems.Count; i++)
            {
                Inventory.Instance.AddItem(SuccessItems[i]);
            }
        }
    }
}