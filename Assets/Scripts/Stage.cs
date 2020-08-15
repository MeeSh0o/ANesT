using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public int level = 0;
    public List<string> flags = new List<string>();
    public string[] LevelFlags;
    public static Stage Instance { get; private set; }

    /// <summary>
    /// 集齐所有flag算通关
    /// </summary>
    public static string[] Level1 = new string[]
    {
        "一幅油画",
        "抽屉小游戏.完成",
    };

    private void Awake()
    {
        Instance = this;
        LoadLevel(1);
    }

    /// <summary>
    /// 加载关卡
    /// </summary>
    /// <param name="level"></param>
    public void LoadLevel(int level)
    {
        this.level = level;
        switch (level)
        {
            case 1:
                LevelFlags = Level1;
                break;
        }
    }

    public bool IsMissionComplete()
    {
        return LevelFlags.All(f => flags.Contains(f));
    }

    public void AddFlag(string flag)
    {
        if (HasFlag(flag))
        {
            return;
        }

        flags.Add(flag);
    }

    public bool HasFlag(string flag)
    {
        return flags.Contains(flag);
    }
}