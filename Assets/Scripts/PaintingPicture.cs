using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingPicture : MonoBehaviour
{
    public Sprite[] pictures;
    public SpriteRenderer renerer;
    private int index = 0;

    void Start()
    {
    }

    public bool NextPicture()
    {
        if (index >= pictures.Length)
        {
            return true;
        }

        SetPicture(index);
        index++;
        return index >= pictures.Length;
    }

    public void SetPicture(int index)
    {
        if (index >= pictures.Length)
        {
            return;
        }

        renerer.sprite = pictures[index];
    }
}