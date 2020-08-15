using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseUpView : MonoBehaviour
{
    // private Dictionary<string, MiniGame> miniGames = new Dictionary<string, MiniGame>();

    // Start is called before the first frame update
    public Image viewImage;

    private void Start()
    {
        var games = GetComponentsInChildren<MiniGame>();
        foreach (var miniGame in games)
        {
            miniGame.Init(this);
        }

        Instance = this;
        Hide();
    }

    public void Show(Sprite sprite = null)
    {
        gameObject.SetActive(true);
        if (sprite)
        {
            viewImage.sprite = sprite;
            viewImage.SetNativeSize();
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OpenMiniGame(string name)
    {
        var games = GetComponentsInChildren<MiniGame>(true);
        foreach (var miniGame in games)
        {
            if (miniGame.GameName == name)
            {
                Show();
                miniGame.Show();
                break;
            }
        }
    }

    public static CloseUpView Instance { get; private set; }
}