using System.Collections;
using System.Collections.Generic;
using ByteSheep.Events;
using UnityEngine;

public class DelayEventUtil : MonoBehaviour
{
    [Header("注解")]
    public string Text;

    [Header("延迟时间")]
    public float TimeSec;

    [Header("延迟事件")]
    public QuickEvent DelayEvent;

    private float _currentTime;

    private void OnEnable()
    {
        _currentTime = 0f;
    }

    public void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= TimeSec)
        {
            DelayEvent?.Invoke();
            enabled = false;
        }
    }
}