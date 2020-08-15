using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

/// <summary>
/// 打开抽屉解密小游戏
/// </summary>
public class DrawerMiniGame : MonoBehaviour
{

    public GameObject numberPrefab;
    private Toggle[] numbers = new Toggle[7];
    private List<int[]> highlights = new List<int[]>();
    public GridLayoutGroup layout;
    public GameObject closeGo;
    private bool broadCast = false;

    void Start()
    {
        highlights.Add(new[] {1, 3, 5});
        highlights.Add(new[] {2, 3, 5});
        highlights.Add(new[] {3, 4, 5});
        highlights.Add(new[] {3, 4, 5, 6});
        highlights.Add(new[] {1, 3, 4, 5});
        highlights.Add(new[] {1, 2, 4, 6});
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

        closeGo.AddOnPointerClick((e) => Hide());
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public bool IsAllToggleOn()
    {
        return numbers.All(t => t && t.isOn);
    }

    private void HandleNumber(bool value, int num, Toggle toggle)
    {
        if (broadCast)
        {
            return;
        }

        broadCast = true;

        if (value)
        {
            foreach (int n in highlights[num - 1])
            {
                if (n == num)
                {
                    continue;
                }

                numbers[n].isOn = !numbers[n].isOn;
            }
        }


        broadCast = false;

        if (IsAllToggleOn())
        {
            Stage.Instance.AddFlag("抽屉小游戏.完成");
        }
    }
}