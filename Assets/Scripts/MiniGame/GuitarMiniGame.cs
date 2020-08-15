using System.Collections;
using System.Collections.Generic;
using ByteSheep.Events;
using UnityEngine;
using UnityEngine.UI;

public class GuitarMiniGame : MiniGame
{
    [System.Serializable]
    public class GuitarButtonConfig
    {
        [Header("琴弦按钮")]
        public Button Bowstring;

        [Header("字符")]
        public string Char;

        [Header("按下效果（音效 特效等）")]
        private QuickEvent OnClick;
    }

    [Header("琴弦设定")]
    [SerializeField]
    public List<GuitarButtonConfig> GuitarButtonConfigs;

    [Header("目标字符")]
    public string ContinueString;

    [Header("当前字符")]
    public string CurrentString;

    public Button CloseButton;

    private void Awake()
    {
        CurrentString = "";
        foreach (GuitarButtonConfig config in GuitarButtonConfigs)
        {
            config.Bowstring.onClick.AddListener(() => { OnButtonClick(config.Char); });
        }
        CloseButton.onClick.AddListener(Hide);
    }

    private void OnButtonClick(string guitarChar)
    {
        CurrentString += guitarChar;
        if (CurrentString.EndsWith(ContinueString))
        {
            OnSuccessGame();
            Hide();
        }
    }
}