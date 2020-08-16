using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteRenderer renderer;
    public Transform from;
    public Transform to;
    public float speed = 1f;
    public float interval = 3f;
    private Vector3 fromPos;
    private Vector3 toPos;

    void Start()
    {
        fromPos = from.localPosition;
        toPos = to.localPosition;
    }

    private void OnEnable()
    {
        StartCoroutine("Drop");
    }

    private void OnDisable()
    {
        StopCoroutine("Drop");
    }

    IEnumerator Drop()
    {
        while (true)
        {
            renderer.transform.localPosition = fromPos;
            renderer.gameObject.SetActive(true);
            var dur = 0.0f;
            while (dur <= speed)
            {
                dur += Time.deltaTime;
                renderer.transform.localPosition = Vector3.Lerp(fromPos, toPos, dur / speed);
                renderer.sprite = sprites[((int) (dur / speed)) % sprites.Length];
                yield return null;
            }

            renderer.gameObject.SetActive(false);
            yield return new WaitForSeconds(interval);
        }
    }

    public void HideDrop()
    {
        renderer.gameObject.SetActive(false);
    }
}