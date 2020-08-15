using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 移动的时候让蚂蚁旋转
/// </summary>
public class MoveRotateHelper : MonoBehaviour
{
    private Vector3 _lastPosition;

    private void Start()
    {
        _lastPosition = transform.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector2 deta = transform.position - _lastPosition;

        if (deta.sqrMagnitude > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(deta.y, deta.x) * Mathf.Rad2Deg + 90f);
        }
        _lastPosition = transform.position;
    }
}