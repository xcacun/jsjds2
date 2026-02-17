using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 旋转 : MonoBehaviour
{


    public Vector3 rotateAxis = Vector3.up; // 旋转轴，Y轴为up，X轴right，Z轴forward
    public float rotateSpeed = 90f; // 旋转速度，°/秒，可自行调整

    void Update()
    {
        // 匀速旋转：Time.deltaTime保证不同帧率下速度一致
        transform.Rotate(rotateAxis, rotateSpeed * Time.deltaTime);
    }

    // 可选：添加启停方法，按需调用
    public void StartRotate() { enabled = true; }
    public void StopRotate() { enabled = false; }
}

