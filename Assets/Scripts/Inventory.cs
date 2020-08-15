using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }
    public GridLayoutGroup layout;
    public GameObject itemPrefab;
    public GameObject arrowGo;
    private bool isShow = true;
    private List<InventoryItem> items = new List<InventoryItem>();

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        arrowGo.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (isShow)
            {
                Hide();
            }
            else
            {
                Show();
            }
        });
    }

    public void Show()
    {
        isShow = true;
        transform.DOLocalMove(new Vector3(600, 0, 0), 0.3f);
    }

    public void Hide()
    {
        isShow = false;
        transform.DOLocalMove(new Vector3(800, 0, 0), 0.3f);
    }

    public void AddItem(ClickableItem citem, bool anim = true)
    {
        citem.transform.DOComplete(false);

        if (anim)
        {
            var item = Render(citem);
            item.Hide();
            citem.GetComponent<MaskableGraphic>().DOFade(0, 0.05f).SetDelay(0.20f);
            citem.transform.DOMove(item.transform.position, 0.3f).onComplete = () =>
            {
                item.Show();
                citem.Hide();
            };
        }
        else
        {
            Render(citem);
        }
    }

    private InventoryItem Render(ClickableItem citem)
    {
        var go = Instantiate(itemPrefab, layout.transform);
        go.SetActive(true);
        var item = go.GetComponent<InventoryItem>();
        item.Set(citem);
        items.Add(item);
        return item;
    }
}