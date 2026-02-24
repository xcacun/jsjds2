using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGongjiangWalk : MonoBehaviour
{
    public GameObject player;
    public GameObject gongjiang;
    void Start()
    {
        player.gameObject.GetComponent<Animator>()?.Play("walk1");
        player.gameObject.GetComponent<Animator>()?.Play("walk");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
