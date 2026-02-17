using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Camera UIcamera;

 
    void Update()
    {
       
        transform.LookAt(UIcamera.transform.position);
    }
}
