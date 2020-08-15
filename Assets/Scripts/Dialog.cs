using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator ShowMessage(
        GameObject skipBord,
        Text label,
        string message,
        float speed = 0.05f
    )
    {
        bool skip = false;
        skipBord.AddOnPointerClick(e => skip = true);
        StringBuilder typed = new StringBuilder();
        for (var i = 0; i < message.Length; i++)
        {
            char ch = message[i];
            typed.Append(ch);
            label.text = typed.ToString();
            if (skip)
            {
                break;
            }
            yield return new WaitForSeconds(speed);
        }

        label.text = message;
        while (!skip)
        {
            yield return null;
        }
    }
}