using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public static Audio instance;


    private Clip[] BGM = new Clip[4];

    private GameObject clipPrefab;

    private Dictionary<string, AudioClip> audioClipsDict = new Dictionary<string, AudioClip>();



    private void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }

        clipPrefab = Resources.Load("Audio/AudioClip") as GameObject;

        for (int i = 0; i < BGM.Length; i++)
        {
            BGM[i] = Instantiate(clipPrefab, transform).GetComponent<Clip>();
            BGM[i].SetPlayer(true);
            BGM[i].gameObject.name = "chanel" + (i + 1);
        }
    }
    /// <summary>
    /// 播放BGM，音乐会一直循环播放
    /// </summary>
    /// <param name="fileName">音频文件名</param>
    public void PlayMusic(string fileName)
    {
        AudioClip clip = GetAudioClip(fileName);
        if (clip != null)
        {
            BGM[1].Play(clip);
        }
    }

    /// <summary>
    /// 播放BGM，相同轨道的bgm互斥，音乐会一直循环播放
    /// </summary>
    /// <param name="fileName">音频文件名</param>
    /// <param name="chanel">轨道</param>
    public void PlayMusic(string fileName, int chanel)
    {
        AudioClip clip = GetAudioClip(fileName);
        if (clip != null)
        {
            if (chanel > 3)
            {
                Debug.LogWarning("轨道超出上限");
                return;
            }
            BGM[chanel].Play(clip);
        }
    }
    /// <summary>
    /// 播放BGM，相同轨道的bgm互斥，音乐会一直循环播放
    /// </summary>
    /// <param name="fileName">音频文件名</param>
    /// <param name="chanel">轨道</param>
    /// <param name="Volume">音量</param>
    public void PlayMusic(string fileName, int chanel, float volume)
    {
        AudioClip clip = GetAudioClip(fileName);
        if (clip != null)
        {
            if (chanel > 3)
            {
                Debug.LogWarning("轨道超出上限");
                return;
            }
            BGM[chanel].Play(clip, volume);
        }
    }
    /// <summary>
    /// 播放音效，放完对象就销毁
    /// </summary>
    /// <param name="fileName">音频文件名</param>
    public void PlaySFX(string fileName)
    {
        AudioClip clip = GetAudioClip(fileName);      
        if(clip != null)
        { 
            Clip clipObject = Instantiate(clipPrefab, transform).GetComponent<Clip>();
            clipObject.name = "SFX" + fileName;
            clipObject.SetPlayer(false);
            clipObject.Play(clip);
        }
    }
    /// <summary>
    /// 播放音效，放完对象就销毁
    /// </summary>
    /// <param name="fileName">音频文件名</param>
    /// <param name="Volume">音量</param>
    public void PlaySFX(string fileName, float volume)
    {
        AudioClip clip = GetAudioClip(fileName);
        if (clip != null)
        {
            Clip clipObject = Instantiate(clipPrefab, transform).GetComponent<Clip>();
            clipObject.name = "SFX" + fileName;
            clipObject.SetPlayer(false);
            clipObject.Play(clip, volume);
        }
    }
    /// <summary>
    /// 让目标播放音效，放完对象就销毁
    /// </summary>
    /// <param name="fileName">音频文件名</param>
    /// <param name="Volume">音量</param>
    /// <param name="trans">想要播放音效的物体</param>
    public void PlaySFX(string fileName, float volume, Transform trans)
    {
        AudioClip clip = GetAudioClip(fileName);
        if (clip != null)
        {
            Clip clipObject = Instantiate(clipPrefab, trans).GetComponent<Clip>();
            clipObject.name = "SFX" + fileName;
            clipObject.SetPlayer(false);
            clipObject.Play(clip, volume);
        }
    }
    /// <summary>
    /// 静音指定轨道
    /// </summary>
    /// <param name="chanel">轨道</param>
    /// <param name="isMute">是否静音</param>
    public void MuteChanel(int chanel, bool isMute)
    {
        if (chanel > 3)
        {
            Debug.LogWarning("轨道超出上限");
            return;
        }
        BGM[chanel].Mute(isMute);
    }

    private AudioClip GetAudioClip(string fileName)
    {
        if (audioClipsDict.ContainsKey(fileName))
        {
            return audioClipsDict[fileName];
        }
        else
        {
            AudioClip clip = Resources.Load("Audio/" + fileName) as AudioClip;
            if (clip != null)
            {
                audioClipsDict.Add(fileName, clip);
                return clip;
            }
            else
            {
                Debug.LogWarning("播放了不存在的音频： " + fileName);
                return null;
            }
        }
    }

    public void Test_PlaySFX()
    {
        PlaySFX("Kongling2");
    }
    public void Test_PlayMusic()
    {
        PlayMusic("ClickSFX01", 0);
    }
    public void Test_SwitchMusic()
    {
        PlayMusic("Kongling1", 0);
    }

}
