using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform target;
    private void LateUpdate()
    {
        Vector3 targetPos = new Vector3(target.position.x, target.position.y+5, target.position.z-5);
        transform.position = targetPos;
    }
}
