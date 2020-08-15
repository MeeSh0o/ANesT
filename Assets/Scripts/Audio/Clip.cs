using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Clip : MonoBehaviour
{
    public AudioSource audioSource;

    private bool isBGM;

    private IEnumerator enumerator = null;

    public void SetPlayer(bool loop)
    {
        isBGM = loop;
        audioSource.loop = loop;
    }

    public void Play(AudioClip clip)
    {
        if(enumerator != null)
        {
            Debug.LogWarning("播放过频繁，播放失败。 " + clip.name);
            return;
        }
        if (isBGM)
        {
            enumerator = PlayBGM(clip);
            StartCoroutine(enumerator);
        }
        else
        {
            audioSource.clip = clip;
            enumerator = PlaySFX();
            StartCoroutine(enumerator);
        }
    }

    public void Play(AudioClip clip, float volume)
    {
        if (enumerator != null)
        {
            Debug.LogWarning("播放过频繁，播放失败。 " + clip.name);
            return;
        }
        if (isBGM)
        {
            enumerator = PlayBGM(clip, volume);
            StartCoroutine(enumerator);
        }
        else
        {
            audioSource.clip = clip;
            enumerator = PlaySFX(volume);
            StartCoroutine(enumerator);
        }
    }

    IEnumerator PlaySFX()
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        Destroy(gameObject);
        enumerator = null;
    }

    IEnumerator PlaySFX(float volume)
    {
        audioSource.volume = volume;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        Destroy(gameObject);
        enumerator = null;
    }

    IEnumerator PlayBGM(AudioClip clip)
    {
        Debug.Log("开始切换bgm");
        while (audioSource.volume > 0.1)
        {
            audioSource.volume -= 3f * Time.deltaTime;
            yield return 0;
        }
        Debug.Log("bgm切换为" + clip.name);
        audioSource.volume = 1f;
        audioSource.clip = clip;
        audioSource.Play();
        enumerator = null;
    }

    IEnumerator PlayBGM(AudioClip clip, float volume)
    {
        Debug.Log("开始切换bgm");
        while (audioSource.volume > 0.1)
        {
            audioSource.volume -= 3f * Time.deltaTime;
            yield return 0;
        }
        Debug.Log("bgm切换为" + clip.name);
        audioSource.volume = volume;
        audioSource.clip = clip;
        audioSource.Play();
        enumerator = null;
    }

    public void Mute(bool mute)
    {
        audioSource.mute = mute;
    }
}
