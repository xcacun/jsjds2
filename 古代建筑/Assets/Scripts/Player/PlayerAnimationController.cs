using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
   public Animator controller;
    public float vectorHorizontal;
    public Rigidbody rigbody;

    private void Awake()
    {
        controller = gameObject.GetComponent<Animator>();
        rigbody = gameObject.GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vectorHorizontal = new Vector3(rigbody.velocity.x,0, rigbody.velocity.z).magnitude;
        controller.SetFloat("VectorHorizontal", vectorHorizontal);
    }
}
