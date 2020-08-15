using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EnterEvent : MonoBehaviour
{
    public Button start;
    public Button people;
    public Image Cast;
    void Start()
    {
        start.onClick.AddListener(ChangeScene);
        people.onClick.AddListener(ShowCast);

    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void ShowCast()
    {
        Debug.LogWarning("11");
        Cast.gameObject.SetActive(true);
    }

    public void CloseCast()
    {
        Cast.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
