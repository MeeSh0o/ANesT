using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private Vector3 showPos;
    private Vector2 hidePos;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        showPos = transform.localPosition;
        hidePos = transform.localPosition + new Vector3(200, 0, 0);
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
        transform.DOComplete();
        transform.DOLocalMove(showPos, 0.3f);
    }

    public void Hide()
    {
        isShow = false;
        transform.DOComplete();
        transform.DOLocalMove(hidePos, 0.3f);
    }

    public void AddItem(ClickableItem citem, bool anim = true)
    {
        citem.transform.DOComplete(false);
        var rawItem = citem.item;
        if (anim)
        {
            var item = Render(rawItem);
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
            Render(rawItem);
        }
    }

    public List<Item> GetSelectedItems()
    {
        return items.Where(i => i.isSelected).Select(i => i.rawItem).ToList();
    }

    public void AddItem(Item item)
    {
        Render(item);
    }

    private InventoryItem Render(Item rawItem)
    {
        var go = Instantiate(itemPrefab, layout.transform);
        go.SetActive(true);
        var item = go.GetComponent<InventoryItem>();
        item.Set(rawItem);
        items.Add(item);
        return item;
    }
}