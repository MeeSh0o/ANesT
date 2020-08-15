using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseUpView : MonoBehaviour
{
    // Start is called before the first frame update
    public Image viewImage;

    void Start()
    {
        Hide();
    }

    public void Show(Sprite sprite)
    {
        gameObject.SetActive(true);
        viewImage.sprite = sprite;
        viewImage.SetNativeSize();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}