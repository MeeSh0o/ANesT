using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastBack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public void LastBackGround()
    {
        SceneManager.LoadScene("GameOver");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
