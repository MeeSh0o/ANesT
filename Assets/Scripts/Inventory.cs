using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GridLayoutGroup layout;
    public GameObject itemPrefab;
    public GameObject arrowGo;
    private bool isShow = true;

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
}