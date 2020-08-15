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
    [NonSerialized] public bool autoHide = true;

    public void ShowMessage(string message, float speed = 0.05f)
    {
        StartCoroutine(_ShowMessage(message, speed));
    }

    private IEnumerator _ShowMessage(string message, float speed = 0.05f)
    {
        Show();
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

        if (autoHide) Hide();
        skipBordGo.RemoveEventEntry(entry);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}