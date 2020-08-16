using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public GameObject skipBordGo;
    public Text messageText;

    protected virtual void Awake()
    {
        Hide();
    }

    public void ShowMessage(string message)
    {
        ShowMessage(message, null, 0.05f, true);
    }

    public void ShowMessage(string message, Action callback, float speed = 0.05f, bool autoHide = true)
    {
        Show();
        StartCoroutine(_ShowMessage(message, callback, speed, autoHide));
    }

    private IEnumerator _ShowMessage(string message, Action callback, float speed = 0.05f, bool autoHide = true)
    {
        messageText.text = string.Empty;
        yield return new WaitForSeconds(0.1f);
        bool skip = false;
        var entry = skipBordGo.AddOnPointerClick(e => skip = true);
        StringBuilder typed = new StringBuilder();
        for (var i = 0; i < message.Length; i++)
        {
            char ch = message[i];
            typed.Append(ch);
            messageText.text = typed.ToString();
            if (skip)
            {
                break;
            }

            yield return new WaitForSeconds(speed);
        }

        messageText.text = message;
        while (!skip)
        {
            yield return null;
        }

        Debug.Log("Hide");
        if (autoHide) Hide();
        skipBordGo.RemoveEventEntry(entry);
        callback?.Invoke();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}