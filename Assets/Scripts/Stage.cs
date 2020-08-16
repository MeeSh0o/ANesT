using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public List<string> flags = new List<string>();
    public Level[] levels;
    public static Stage Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        LoadLevel(0);
    }

    /// <summary>
    /// 加载关卡
    /// </summary>
    /// <param name="index"></param>
    public void LoadLevel(int index)
    {
        for (int i = 0; i < this.levels.Length; i++)
        {
            var l = levels[i];
            l.events.SetActive(i == index);
            l.objects.SetActive(i == index);
        }

        flags.Clear();
        Inventory.Instance.Clear();
    }

    public bool IsMissionComplete()
    {
        //return LevelFlags.All(f => flags.Contains(f));
        return false;
    }

    public void AddFlag(string flag)
    {
        if (HasFlag(flag))
        {
            return;
        }

        flags.Add(flag);

        switch (flag)
        {
            case "对话.第一关完成":
                Narratage.Instance.ShowMessage("第一关完成", () =>
                {
                    Narratage.Instance.Hide();
                    LoadLevel(1);
                }, 0.05f, false);
                break;
        }
    }

    public bool HasFlag(string flag)
    {
        return flags.Contains(flag);
    }
}