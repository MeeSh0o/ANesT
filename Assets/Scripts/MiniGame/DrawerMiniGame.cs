using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

/// <summary>
/// 打开抽屉解密小游戏
/// </summary>
public class DrawerMiniGame : MiniGame
{
    public GameObject numberPrefab;
    private Toggle[] numbers = new Toggle[7];
    private List<int[]> highlights = new List<int[]>();
    public GridLayoutGroup layout;
    public GameObject closeGo;
    private bool broadCast = false;
    private CloseUpView view;

    private void Start()
    {
        //下标都从1开始
        highlights.Add(new[] { 0 });
        highlights.Add(new[] { 2, 4 });
        highlights.Add(new[] { 1, 3, 5 });
        highlights.Add(new[] { 2, 6 });
        highlights.Add(new[] { 1, 5 });
        highlights.Add(new[] { 2, 4, 6 });
        highlights.Add(new[] { 3, 5 });
        for (int i = 1; i <= 6; i++)
        {
            var go = Instantiate(numberPrefab, layout.transform);
            go.SetActive(true);
            go.transform.GetComponentInChildren<Text>().text = i.ToString();
            var toggle = go.GetComponent<Toggle>();
            numbers[i] = toggle;
            var num = i;
            toggle.onValueChanged.AddListener((v) => HandleNumber(v, num, toggle));
           
        }
        closeGo.AddOnPointerClick((e) =>
        {
            Hide();
        });
    }

    public override MiniGame Init(CloseUpView view)
    {
        this.view = view;
        bool[] on = new[] { true, true, false, true, true, true, false };
        for (int i = 1; i <= 6; i++)
        {
            numbers[i].isOn = on[i];
        }
        return this;
    }

    public bool IsAllToggleOn()
    {
        return numbers.Skip(1).All(t => t.isOn);
    }

    private void HandleNumber(bool value, int num, Toggle toggle)
    {
        if (broadCast)
        {
            return;
        }

        broadCast = true;

        //if (value)
        {
            foreach (int n in highlights[num])
            {
                numbers[n].isOn = !numbers[n].isOn;
                //不取反
                //numbers[n].isOn = true;
            }
        }

        broadCast = false;
        if (IsAllToggleOn())
        {
            OnSuccessGame();
        }
    }
}