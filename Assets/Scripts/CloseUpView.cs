using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseUpView : MonoBehaviour
{
    private void Start()
    {
        var games = GetComponentsInChildren<MiniGame>();
        foreach (var miniGame in games)
        {
            miniGame.Init(this);
            miniGame.gameObject.SetActive(false);
        }

        Instance = this;
    }

    public void OpenMiniGame(string name)
    {
        var games = GetComponentsInChildren<MiniGame>(true);
        foreach (var miniGame in games)
        {
            if (miniGame.GameName == name)
            {
                miniGame.Show();
                break;
            }
        }
    }

    public static CloseUpView Instance { get; private set; }
}