using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public GameObject[] picture = new GameObject[4];
    public Vector3[] cameraPos = new Vector3[4];
    public int currentScene;
    public Camera camera;

    private void Awake()
    {
        camera.transform.position = cameraPos[currentScene];
    }

    public void SetCurrentScene(int scene)
    {
        currentScene = scene;
        camera.transform.position = cameraPos[currentScene];
    }

    public void TurnRight()
    {
        switch (currentScene)
        {
            case 0:
                SetCurrentScene(3);
                break;
            case 1:
                SetCurrentScene(2);
                break;
            case 2:
                SetCurrentScene(0);
                break;
            case 3:
                SetCurrentScene(1);
                break;
        }
    }

    public void TurnLeft()
    {
        switch (currentScene)
        {
            case 0:
                SetCurrentScene(2);
                break;
            case 1:
                SetCurrentScene(3);
                break;
            case 2:
                SetCurrentScene(1);
                break;
            case 3:
                SetCurrentScene(0);
                break;
        }
    }

    
}


/*
 * 0 wall
 * 1 empty
 * 2 window
 * 3 door
 */