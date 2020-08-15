using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseUpView : MonoBehaviour
{
    public const string MINI_GAME_DRAWER = "抽屉小游戏";

    private Dictionary<string, MiniGame> miniGames = new Dictionary<string, MiniGame>();

    // Start is called before the first frame update
    public Image viewImage;

    void Start()
    {
        Instance = this;
        miniGames.Add(MINI_GAME_DRAWER, GetComponentInChildren<DrawerMiniGame>().Init(this));
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
        if (!miniGames.ContainsKey(name))
        {
            return;
        }

        Show();
        miniGames[MINI_GAME_DRAWER].Show();
    }

    public static CloseUpView Instance { get; private set; }
}